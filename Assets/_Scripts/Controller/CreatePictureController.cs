using SimpleJSON;
using UnityEngine;
using Assets._Scripts.Model;


//Class has also included the testing of reading a JSON with SimpleJSON for Unity
//Was first used as Class to create Pictures during runtime on Mobiles, but that function was put on Server instead

//TODO: Call Server and Let a picture be created

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

        //Read the JSON Data File
        public void Test()
        {
            var test = JSONNode.Parse(LoadResourceTextfile("PicturePlaceHolderLayer.json"));
            Debug.Log(test["Stage1"]);
            for (int i = 0; i < test["Stage1"][0].Count; i++)
            {
                picModel.MakeStage1Model(1, i, test["Stage1"][0][i]);
                Debug.Log(test["Stage1"][0][i]);
            }
        }
    }
}
