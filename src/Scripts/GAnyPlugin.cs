using UnityEngine;

namespace Gx
{
    /// <summary>
    /// GAny initializes and provides plugin loading methods
    /// </summary>
    public class GAnyPlugin
    {
        private static GAnyPlugin _instance;

        public static GAnyPlugin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GAnyPlugin();
                }

                return _instance;
            }
        }


        private bool _isInit;

        public bool Init()
        {
            if (_isInit)
            {
                return true;
            }

            Debug.Log("GAnyPlugin Init");

            _isInit = true;
            
            GAnyNative.Instance.Init();

            var gEnv = GAny.Env();

            var setPluginSearchPathFn = gEnv.GetItem("setPluginSearchPath");
            string pluginDir = GetPluginDir();

            if (!setPluginSearchPathFn.IsFunction())
            {
                Debug.LogError("GAnyPlugin setPluginSearchPath failure!!");
                _isInit = false;
                return false;
            }

            setPluginSearchPathFn.Call(pluginDir);

            Debug.Log("GAnyPlugin Init ok.");
            return true;
        }

        public void UnInit()
        {
            if (!_isInit)
            {
                return;
            }

            _isInit = false;

            GAnyNative.Instance.UnInit();
        }

        public bool CheckSupport()
        {
            if (!_isInit)
            {
                return false;
            }

            try
            {
                var obj = GAny.Object();
                return obj.IsObject();
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                return false;
            }
        }

        public bool LoadPlugin(string pluginName)
        {
            if (!_isInit)
            {
                return false;
            }
            var loadPlugin = GAny.Env().GetItem("loadPlugin");
            if (!loadPlugin.IsFunction())
            {
                Debug.LogError("Get function loadPlugin failure.");
                return false;
            }

            return loadPlugin.Call(pluginName).ToBool();
        }

        public bool LoadPlugin(string searchPath, string pluginName)
        {
            if (!_isInit)
            {
                return false;
            }
            var loadPlugin = GAny.Env().GetItem("loadPlugin");
            if (!loadPlugin.IsFunction())
            {
                Debug.LogError("Get function loadPlugin failure.");
                return false;
            }

            return loadPlugin.Call(searchPath, pluginName).ToBool();
        }

        private string GetPluginDir()
        {
#if UNITY_EDITOR
#if UNITY_STANDALONE_WIN
            return Application.dataPath + "/Plugins/GAnyUnity/Libs/x86_64/";
#elif UNITY_STANDALONE_OSX
            return Application.dataPath + "/Plugins/GAnyUnity/Libs/MacOS/";
#endif
#else
#if UNITY_STANDALONE_WIN
            return Application.dataPath + "/Plugins/x86_64";
#elif UNITY_STANDALONE_OSX
            return Application.dataPath + "/PlugIns/";
#endif
            return "";
#endif
        }
    }
}