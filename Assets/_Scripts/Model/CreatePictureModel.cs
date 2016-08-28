using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Scripts.Model
{

    public class CreatePictureModel
    {
        private Dictionary<String, String> m_StageOne;
        private List<MonsterPicStageModel> m_StageTwo;
        private List<MonsterPicStageModel> m_StageThree;

        public CreatePictureModel()
        {
            m_StageOne = new Dictionary<string, string>();//new List<MonsterPicStageModel>();
            m_StageTwo      = new List<MonsterPicStageModel>();
            m_StageThree    = new List<MonsterPicStageModel>();

         }

        public void MakeStage1Model(int _Index,int _Layer, String _LayerName)
        {
            AddNewLayer(_Index, "Layer" + _Layer, _LayerName);
        }

        public void AddNewLayer(int _Index, String _Key, String _Name)
        {
            if (_Index == 1)
            {
                m_StageOne.Add(_Key, _Name);
            }
            //TODO Stage 2 and 3 Add
        }

        public String GetLayer(String _Key)
        {

            //TODO: Add Stage 2 and 3
            String value;
            if (!m_StageOne.TryGetValue(_Key, out value))
                value = null;
            return value;
        }

        public bool CheckIfExiast(String _Key)
        {
            //TODO: Add Stage 2 and 3
            return m_StageOne.ContainsKey(_Key);
        }


    }
}
