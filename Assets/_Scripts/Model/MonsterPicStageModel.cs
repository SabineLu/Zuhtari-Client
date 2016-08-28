using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Scripts.Model
{
    
    class MonsterPicStageModel
    {
        private Dictionary<String, String> StagePicLayer;

        public MonsterPicStageModel()
        {
            StagePicLayer = new Dictionary<String, String>();
        }

        public void AddNewLayer(String _Key, String _Name)
        {
            StagePicLayer.Add(_Key,_Name);
        }

        public String GetLayer(String _Key)
        {
            String value;
            if(!StagePicLayer.TryGetValue(_Key, out value))
                value = null;
            return value;
        }

        public bool CheckIfExiast(String _Key)
        {
            return StagePicLayer.ContainsKey(_Key);
        }

    }
}
