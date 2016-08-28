using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleJSON;
using UnityEngine;
using Assets._Scripts.Model;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

namespace Assets._Scripts.Controller
{
    public class CreatePictureController
    {
        private CreatePictureModel picModel;

        public void Init()
        {
            picModel = new CreatePictureModel();
        }

        //Load JSON Data from Resources into a Model
        public string LoadResourceTextfile(string path)
        {

            string filePath = "JSON/" + path.Replace(".json", "");

            TextAsset targetFile = Resources.Load<TextAsset>(filePath);

            return targetFile.text;
        }

        public void Test()
        {
           var test = JSONNode.Parse(LoadResourceTextfile("PicturePlaceHolderLayer.json"));
            Debug.Log(test["Stage1"]);
            for (int i = 0; i < test["Stage1"][0].Count; i++)
            {
                picModel.MakeStage1Model(1,i, test["Stage1"][0][i]);
                Debug.Log(test["Stage1"][0][i]);
            }
            Debug.Log(test["Stage2"]);
            Debug.Log(test["Stage3"]);
            Debug.Log(test);
        }

        public System.Drawing.Bitmap MergeTwoImages(List<Image> _Images)
        {
            foreach (var item in _Images)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("firstImage");
                }
            }


            int outputImageWidth = _Images[0].Width;// > secondImage.Width ? firstImage.Width : secondImage.Width;

            int outputImageHeight = firstImage.Height;// + secondImage.Height + 1;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(new Point(0, firstImage.Height + 1), secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }
    }
}
