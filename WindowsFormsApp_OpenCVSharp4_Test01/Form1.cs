using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//kojima
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Text;

/// <summary>
/// http://blog.livedoor.jp/user5/archives/46255389.html
/// https://www.ipentec.com/document/csharp-using-opencvsharp-x64-type-initialization-exception
/// https://www.atmarkit.co.jp/fdotnet/dotnettips/458picboxdraw/picboxdraw.html
/// https://dobon.net/vb/dotnet/graphics/index.html
/// </summary>
namespace WindowsFormsApp_OpenCVSharp4_Test01 {
    public partial class Form1 : Form {

        int WIDTH = 320;  int HEIGHT = 240;
        //int WIDTH = 640; int HEIGHT = 480;
        Mat frame;
        VideoCapture capture;
        Bitmap bmp;
        Graphics graphic;


        //Path
        string strFolderPath = null;            //Exeファイル実行フォルダPath


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1() {
            InitializeComponent();

            //実行ファイルのあるフォルダPath取得
            strFolderPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath( Environment.GetCommandLineArgs()[0]));

        }



        /// <summary>
        /// フォームClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {

            if (backgroundWorker1.IsBusy) {
                //スレッドの終了を待機
                backgroundWorker1.CancelAsync();
                while (backgroundWorker1.IsBusy)
                    Application.DoEvents();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {

            BackgroundWorker bw = (BackgroundWorker)sender;

            while (!backgroundWorker1.CancellationPending) {
                //画像取得
                //capture.Read(frame); //これだとエラー
                capture.Grab();
                NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(capture.CvPtr, frame.CvPtr);

                bw.ReportProgress(0);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {

            //描画
            graphic.DrawImage(bmp, 0, 0, frame.Cols, frame.Rows);

        }



        /// <summary>
        /// キャプチャ開始ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptureStart_Click(object sender, EventArgs e) {

            if (!backgroundWorker1.IsBusy) { 

                //カメラ画像取得用のVideoCapture作成
                capture = new VideoCapture(0);
                if (!capture.IsOpened()) {
                    MessageBox.Show("cannot open camera");
                    this.Close();
                }
                capture.FrameWidth = WIDTH;
                capture.FrameHeight = HEIGHT;

                //取得先のMat作成
                frame = new Mat(HEIGHT, WIDTH, MatType.CV_8UC3);

                //表示用のBitmap作成
                bmp = new Bitmap(frame.Cols, frame.Rows, (int)frame.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, frame.Data);

                //PictureBoxを出力サイズに合わせる
                picBoxLive.Width = frame.Cols;
                picBoxLive.Height = frame.Rows;

                //描画用のGraphics作成
                graphic = picBoxLive.CreateGraphics();

                //画像取得スレッド開始
                backgroundWorker1.RunWorkerAsync();
            }
        }



        /// <summary>
        /// キャプチャ終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptureEnd_Click(object sender, EventArgs e) {

            //スレッドの終了を待機
            backgroundWorker1.CancelAsync();
            while (backgroundWorker1.IsBusy)
                Application.DoEvents();

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetStillImage_Click(object sender, EventArgs e) {

            //----picturebox画像コピー----
            picBoxSrc.Image = bmp;


            /*
            //pictureBox2.Image = (Image)pictureBox1.Image.Clone();
            //pictureBox2.Image = pictureBox1.Image;

            Bitmap img = new Bitmap(pictureBox1.Image);
            //作成した画像を表示する
            pictureBox2.Image = img;
            //Refresh();
            */

            /*
            //----黒背景円弧---
            Bitmap img = new Bitmap(100, 100);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(img);
            //全体を黒で塗りつぶす
            g.FillRectangle(Brushes.Black, g.VisibleClipBounds);
            //黄色い扇形を描画する
            g.DrawPie(Pens.Yellow, 60, 10, 80, 80, 30, 300);
            //リソースを解放する
            g.Dispose();
            //作成した画像を表示する
            pictureBox2.Image = img;
            //Refresh();
            */


        }



        /// <summary>
        /// 画像読込
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadPicture_Click(object sender, EventArgs e) {

            openFileDialog1.Filter = "画像ファイル|*.gif;*.jpg;*.png|すべてのファイル|*.*";     // フィルターの設定
            openFileDialog1.ShowDialog();                                                       // ファイル選択ダイアログを表示

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {

            //picBoxSrc.SizeMode = PictureBoxSizeMode.Zoom;                     // イメージの表示方法を設定（サイズ比率を維持したまま拡大/縮小）
            picBoxSrc.Image = Image.FromFile(openFileDialog1.FileName);       // PictureBoxにイメージを読み込む



            //----Gray変換-----------------------
            //画像を読み込む
            //Mat src = new Mat(pictureBox2.Image, ImreadModes.Grayscale);
            Mat matSrc = BitmapConverter.ToMat((Bitmap)picBoxSrc.Image);
            Mat matGray = matSrc.Clone();
            Mat matGreen = matSrc.Clone();
            Mat matRed = matSrc.Clone();
            Mat matBlue = matSrc.Clone();

            Cv2.CvtColor(matSrc, matGray, ColorConversionCodes.BGRA2GRAY);          //Gray変換
            Cv2.CvtColor(matGray, matGray, ColorConversionCodes.GRAY2BGRA);         //Gray変換
            picBoxSrcGray.Image = BitmapConverter.ToBitmap(matGray);                //描画


            //RGB分離
            Mat[] matArr = Cv2.Split(matSrc);
            picBoxSrcBlue.Image = BitmapConverter.ToBitmap(matArr[0]);              //描画
            picBoxSrcGreen.Image = BitmapConverter.ToBitmap(matArr[1]);             //描画
            picBoxSrcRed.Image = BitmapConverter.ToBitmap(matArr[2]);               //描画
            //picBoxSrcBlue.Image = BitmapConverter.ToBitmap(matArr[0]);              //描画
            //picBoxSrcGreen.Image = BitmapConverter.ToBitmap(matArr[1]);             //描画
            //picBoxSrcRed.Image = BitmapConverter.ToBitmap(matArr[2]);               //描画

        }



        /// <summary>
        /// 画像保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePicture_Click(object sender, EventArgs e) {

            saveFileDialog1.Filter = "PNG形式|*.png|JPEG形式|*.jpeg|GIF形式|*.gif";             //フィルターの設定
            saveFileDialog1.ShowDialog();                                                       // ファイル保存ダイアログを表示

        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e) {

            string extension = System.IO.Path.GetExtension(saveFileDialog1.FileName);

            switch (extension.ToUpper()) {
                case ".PNG":
                    // PictureBoxのイメージをGIF形式で保存する
                    picBoxDst.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case ".JPEG":
                    // PictureBoxのイメージをJPEG形式で保存する
                    picBoxDst.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".GIF":
                    // PictureBoxのイメージをGIF形式で保存する
                    picBoxDst.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
            }
        }


        ///// <summary>
        ///// Mat_Bmp変換
        ///// </summary>
        ///// <param name="image"></param>
        ///// <returns></returns>
        //public static Bitmap MatToBitmap(Mat image) {
        //    return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        //} // end of MatToBitmap function



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyPicture_Click(object sender, EventArgs e) {
            picBoxDst.Image = picBoxSrc.Image;
        }





        /***********************************************************************************************************************
         * 
         * 2値化
         * 
         ************************************************************************************************************************/
        /// <summary>
        /// 2値化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <example>
        /// http://www.kanenote.org/blog/?p=1180
        /// </example>
        private void btnThreshold_Click(object sender, EventArgs e) {

            //画像を読み込む
            //Mat src = new Mat(pictureBox2.Image, ImreadModes.Grayscale);
            Mat src = BitmapConverter.ToMat((Bitmap)picBoxSrcGray.Image);

            //既にGray変換済み
            //Gray変換
            Cv2.CvtColor(src, src, ColorConversionCodes.BGRA2GRAY);

            //二値化後画像
            Mat dst = src.Clone();

            //二値化
            //http://labs.eecs.tottori-u.ac.jp/sd/Member/oyamada/OpenCV/html/py_tutorials/py_imgproc/py_thresholding/py_thresholding.html
            //Binary = 0
            //BinaryInv = 1
            //Trunc = 2
            //Tozero = 3
            //TozeroInv = 4
            //Mask = 7
            //Otsu = 8
            //Triangle = 16
            Cv2.Threshold(src, dst, 0, 255, ThresholdTypes.Otsu);

            //適応的敷地処理
            //http://schima.hatenablog.com/entry/2013/10/19/085019
            //AdaptiveThresholdTypes.GaussianC
            //AdaptiveThresholdTypes.MeanC
            //
            Cv2.AdaptiveThreshold(src, dst, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 9, 12);

            picBoxDst.Image = BitmapConverter.ToBitmap(dst);


            /*
            //画像の表示
            using (new Window("src", WindowMode.AutoSize, src));
            using (new Window("dst", WindowMode.AutoSize, dst));

            //Form に追加した Picture Box と同じサイズではまる Bitmap を生成
            Bitmap canvas = new Bitmap(picBoxSrc.Width, picBoxSrc.Height);

            //canvas オブジェクト上の Image を操作するために，Graphics オブジェクトを取得
            Graphics g = Graphics.FromImage(canvas);

            // canvas 上での Image 操作の際の補完方法を指定
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            //表示する画像
            Bitmap bitimg = MatToBitmap(dst);

            //画像表示位置、サイズを指定する
            g.DrawImage(bitimg, 0, 0, 225, 225);

            //メモリクリア
            bitimg.Dispose();
            g.Dispose();

            //pictureboxに紐付け
            picBoxDst.Image = canvas;
            */

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarThreshold_ValueChanged(object sender, EventArgs e) {

            //画像を読み込む
            //Mat src = new Mat(pictureBox2.Image, ImreadModes.Grayscale);
            Mat matSrcGray = BitmapConverter.ToMat((Bitmap)picBoxSrcGray.Image);

            //Gray変換
            Cv2.CvtColor(matSrcGray, matSrcGray, ColorConversionCodes.BGRA2GRAY);

            //二値化後画像
            Mat dst = matSrcGray.Clone();

            //二値化
            //http://labs.eecs.tottori-u.ac.jp/sd/Member/oyamada/OpenCV/html/py_tutorials/py_imgproc/py_thresholding/py_thresholding.html
            //Binary = 0
            //BinaryInv = 1
            //Trunc = 2
            //Tozero = 3
            //TozeroInv = 4
            //Mask = 7
            //Otsu = 8
            //Triangle = 16
            Cv2.Threshold(matSrcGray, dst, trackBarThreshold.Value, 255, ThresholdTypes.Binary);

            //出力画像表示
            Cv2.CvtColor(dst, dst, ColorConversionCodes.GRAY2BGRA);         //Gray変換
            picBoxDst.Image = BitmapConverter.ToBitmap(dst);

        }


        /// <summary>
        /// ラベリング
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <example>
        /// http://schima.hatenablog.com/entry/2015/08/19/215523
        /// </example>
        private void btnLabelling_Click(object sender, EventArgs e) {

            //画像準備
            Mat matSrcLabelling  = BitmapConverter.ToMat((Bitmap)picBoxDst.Image);
            Mat matGrayLabelling = matSrcLabelling.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat matBinary = matGrayLabelling.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);

            //ラベリング実行
            Mat matLabel = new Mat();
            int nLabels = Cv2.ConnectedComponents(matBinary, matLabel, PixelConnectivity.Connectivity8, MatType.CV_32SC1);


            //色分け画像作成
            Scalar[] colors = Enumerable.Range(0, nLabels + 1).Select(_ => Scalar.RandomColor()).ToArray();
            colors[0] = Scalar.Black;

            int rows = matBinary.Rows;
            int cols = matBinary.Cols;
            var dst = new Mat(rows, cols, MatType.CV_8UC3);
            var labelIndexer = matLabel.GetGenericIndexer<int>();
            var dstIndexer = dst.GetGenericIndexer<Vec3b>();

            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    int labelValue = labelIndexer[y, x];
                    dstIndexer[y, x] = colors[labelValue].ToVec3b();
                }
            }

            //描画
            picBoxDst.Image = BitmapConverter.ToBitmap(dst);

        }






        /***********************************************************************************************************************
         * 
         * Tesseract-OCR
         * 
         ************************************************************************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <example>
        /// http://www.kanenote.org/blog/?p=1228
        /// https://qiita.com/nobi1234/items/c8d7b748c1aa31d771a1
        /// http://whoopsidaisies.hatenablog.com/entry/2013/12/16/174819
        /// https://tesseract-ocr.github.io/tessdoc/Data-Files.html
        /// https://kakusuke98.hatenablog.com/entry/2019/11/14/004609
        /// http://blog.qes.co.jp/2017/06/
        /// 
        /// </example>
        private void btn_tesseract_ocr_Click(object sender, EventArgs e) {

            //言語ファイルの格納先
            //言語（日本語なら"jpn"）               
            //string langPath = @"C:\tessdata";
            string langPath = strFolderPath + @"\tessdata";
            string lngStr = "eng";

            //画像ファイル
            //var img = new Bitmap(@"C:\Temp\test.jpg");
            Bitmap img = (Bitmap)picBoxDst.Image;


            // OCRの実行
            //OpenCvSharp.Text.OCRTesseract.Create("");
            using (var tesseract = new Tesseract.TesseractEngine(langPath, lngStr)) {
                Tesseract.Page page = tesseract.Process(img);       // OCRの実行

                //System.Console.Write(page.GetText());               //表示
                MessageBox.Show(page.GetText());


                //Console.WriteLine(page.GetText());
                //Console.ReadLine();
            }
        }
    }

}
