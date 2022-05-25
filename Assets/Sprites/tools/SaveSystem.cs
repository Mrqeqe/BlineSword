using System.IO;
using UnityEngine;

namespace SaveTools
{
    public static class SaveSystem
    {
        /// <summary>
        /// 利用JSON存储数据，路径为unity默认存档路径
        /// </summary>
        /// <param name="saveFileName">文件名字</param>
        /// <param name="data">存储对象</param>
        public static void SaveByJson(string saveFileName,object data)
        {
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            
                try
                {
                Debug.Log(json);
                    File.WriteAllText(path, json);
                    Debug.Log("成功存储");
                    Debug.Log(path);
                }
                catch (System.Exception e)
                {
                    Debug.LogError("存储未成功" + e);
                }
           
           
        }
        /// <summary>
        /// 从默认路径中导出json文件，创建对象
        /// </summary>
        /// <typeparam name="T">需要构造的对象类型</typeparam>
        /// <param name="fileName">需要读取的文件的名字</param>
        /// <returns>构造好的对象</returns>
        public static T LoadFromJson<T>(string loadFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, loadFileName);
            if (File.Exists(path))
            {
                 try
                 {
                    var json = File.ReadAllText(path);
                    var data = JsonUtility.FromJson<T>(json);
                    Debug.Log("读取成功"+ json);
                    return data;
                }
                catch(System.Exception e)
                {
                    Debug.LogError("读取失败" + e);
                    return default;
                }
            }
            else
            {
                return default;
                Debug.LogWarning("存档文件不存在");
            }
        }
        
        public static void DeleteSaveFile(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            try
            {
                File.Delete(path);
                Debug.Log("删除成功");
            }
            catch(System.Exception e)
            {
                Debug.LogError("删除失败" + e);

            }
        }
    }

}
