using System.IO;
using UnityEngine;

namespace SaveTools
{
    public static class SaveSystem
    {
        /// <summary>
        /// ����JSON�洢���ݣ�·��ΪunityĬ�ϴ浵·��
        /// </summary>
        /// <param name="saveFileName">�ļ�����</param>
        /// <param name="data">�洢����</param>
        public static void SaveByJson(string saveFileName,object data)
        {
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            
                try
                {
                Debug.Log(json);
                    File.WriteAllText(path, json);
                    Debug.Log("�ɹ��洢");
                    Debug.Log(path);
                }
                catch (System.Exception e)
                {
                    Debug.LogError("�洢δ�ɹ�" + e);
                }
           
           
        }
        /// <summary>
        /// ��Ĭ��·���е���json�ļ�����������
        /// </summary>
        /// <typeparam name="T">��Ҫ����Ķ�������</typeparam>
        /// <param name="fileName">��Ҫ��ȡ���ļ�������</param>
        /// <returns>����õĶ���</returns>
        public static T LoadFromJson<T>(string loadFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, loadFileName);
            if (File.Exists(path))
            {
                 try
                 {
                    var json = File.ReadAllText(path);
                    var data = JsonUtility.FromJson<T>(json);
                    Debug.Log("��ȡ�ɹ�"+ json);
                    return data;
                }
                catch(System.Exception e)
                {
                    Debug.LogError("��ȡʧ��" + e);
                    return default;
                }
            }
            else
            {
                return default;
                Debug.LogWarning("�浵�ļ�������");
            }
        }
        
        public static void DeleteSaveFile(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            try
            {
                File.Delete(path);
                Debug.Log("ɾ���ɹ�");
            }
            catch(System.Exception e)
            {
                Debug.LogError("ɾ��ʧ��" + e);

            }
        }
    }

}
