using PrograB3Project.Data;
using PrograB3Project.Events;
using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    public class SaveManager
    {
        private IEventManager _eventManager;
        private List<ISavableComponent> _componentToSaveTable = new List<ISavableComponent>();
        private string _saveFileRelativePath;

       public SaveManager(IEventManager event_manager, string save_file_relative_path) 
        {
            _eventManager = event_manager;
            _saveFileRelativePath = save_file_relative_path;
            _eventManager.RegisterEvent<SavableComponentRegisteredEvent>(OnSavableComponentRegistered);
        }

        public void OnSavableComponentRegistered(Event action)
        {
            SavableComponentRegisteredEvent true_event = (SavableComponentRegisteredEvent)action;
            _componentToSaveTable.Add(true_event.GetComponent());
        }

        public void Save()
        {
            List<string> data_to_save_table = new List<string>();
            data_to_save_table.Add("First Line for fomatting");
            foreach (ISavableComponent component in _componentToSaveTable)
            {
                data_to_save_table.Add(component.Save());
            }

            File.WriteAllLines(_saveFileRelativePath, data_to_save_table);
        }

        public void LoadSaveFile()
        {
            Dictionary<string,string> data = new Dictionary<string,string>();
            GenericDataBase save_data_base = new GenericDataBase();
            save_data_base.LoadDataFromCSV(_saveFileRelativePath);
            List<KeyValuePair<string, string>> data_table = save_data_base.GetData();
            foreach(KeyValuePair<string,string> data_key_value in data_table)
            {
                data.Add(data_key_value.Key.Split("/")[0],data_key_value.Value); //data_key_value.Key.Split("/")[0] because of inventory formatting 
            }

            foreach(ISavableComponent component_to_restore_data_to in _componentToSaveTable)
            {
                string component_id = component_to_restore_data_to.GetID();
                if(data.ContainsKey(component_id))
                {
                    component_to_restore_data_to.RestoreDataFromFile(data[component_id]);
                }
            }
        }
    }
}
