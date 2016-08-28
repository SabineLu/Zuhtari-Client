using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//TODO: Rework class since it may be obselete as Pic is not created on Client
namespace Assets._Scripts.Model
{
    //keeps the layer information for all three stage of a Pet Monster
    public class CreatePictureModel
    {
        //no colelction for Stage 0 as that is just Egg
        private Dictionary<String, String> m_StageOne;  //Layer collection Stage 1 Hatchling Pet
        //private List<MonsterPicStageModel> m_StageTwo;  //layer collection Stage 2 Young Adult Pet
        //private List<MonsterPicStageModel> m_StageThree;    //layer collection Stage 3 Adult

        //
        public CreatePictureModel()
        {
            m_StageOne = new Dictionary<string, string>();//new List<MonsterPicStageModel>();
            //m_StageTwo      = new List<MonsterPicStageModel>();
            //m_StageThree    = new List<MonsterPicStageModel>();

         }

        //TODO: obselte function need to be deleted
        public void MakeStage1Model(int _Index,int _Layer, String _LayerName)
        {
            AddNewLayer(_Index, "Layer" + _Layer, _LayerName);
        }

        //add layer to specific collection
        public void AddNewLayer(int _Index, String _Key, String _Name)
        {
            if (_Index == 1)
            {
                m_StageOne.Add(_Key, _Name);
            }
            //TODO Stage 2 and 3 Add
        }

        //Get the specific layer from the collection
        public String GetLayer(String _Key)
        {

            //TODO: Add Stage 2 and 3
            String value;
            if (!m_StageOne.TryGetValue(_Key, out value))
                value = null;
            return value;
        }

        //Check if the Layer exists in the collection
        public bool CheckIfExiast(String _Key)
        {
            //TODO: Add Stage 2 and 3
            return m_StageOne.ContainsKey(_Key);
        }


    }
}
