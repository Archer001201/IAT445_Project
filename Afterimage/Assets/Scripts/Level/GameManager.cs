using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameManager : MonoBehaviour
    {
        public bool playInEditor;
        public bool initializePosition;
        public int currentSceneIndex;
        public List<string> sceneList;
        
        [Serializable]
        public class ObjectAndPosition
        {
            public GameObject target;
            public Vector3 position;
        }

        public List<ObjectAndPosition> objectAndPositions;
        
        private void Awake()
        {
            if (playInEditor) return;
            SceneManager.LoadScene(sceneList[currentSceneIndex], LoadSceneMode.Additive);
            StartCoroutine(SetActiveSceneWhenLoaded(sceneList[currentSceneIndex]));

            if (!initializePosition) return;
            foreach (var obj in objectAndPositions)
            {
                obj.target.transform.position = obj.position;
            }
        }

        public void AddNextScene()
        {
            currentSceneIndex++;
            SceneManager.LoadSceneAsync(sceneList[currentSceneIndex], LoadSceneMode.Additive);
            StartCoroutine(SetActiveSceneWhenLoaded(sceneList[currentSceneIndex]));
        }

        public void RemovePreviousScene()
        {
            SceneManager.UnloadSceneAsync(sceneList[currentSceneIndex - 1]);
        }
        
        private IEnumerator SetActiveSceneWhenLoaded(string sceneName)
        {
            // 等待场景加载完成
            while (!SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                yield return null;
            }

            // 设置目标场景为活动场景
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            // 确保 Lighting 设置正确
            // ApplyLightingSettings(SceneManager.GetSceneByName(sceneName));
        }
        
        // private void ApplyLightingSettings(Scene activeScene)
        // {
        //     // 确保激活场景的 Lighting 设置被应用
        //     Lightmapping.lightingDataAsset = activeScene.lightingDataAsset;
        //
        //     // 如果有需要，可动态调整天空盒
        //     RenderSettings.skybox = activeScene.name == "GameScene" ? mySkybox : defaultSkybox;
        //
        //     // 更新反射探针
        //     DynamicGI.UpdateEnvironment();
        // }
    }
}
