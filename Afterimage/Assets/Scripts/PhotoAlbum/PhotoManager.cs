using System;
using System.Collections.Generic;
using Level;
using UnityEngine;
using UnityEngine.Serialization;

namespace PhotoAlbum
{
    public class PhotoManager : MonoBehaviour
    {
        public List<GameObject> photos;
        [SerializeField] private LevelDataManager levelDataManager;

        public List<CaptureEventData> captureEvents;

        private void Start()
        {
            // AssignEventAndMaterial();
        }

        public void AssignEventAndMaterial(LevelDataManager levelData)
        {
            levelDataManager = levelData;
            captureEvents = levelDataManager.captureEvents;
            
            for (var i = 0; i < photos.Count; i++)
            {
                if (i < captureEvents.Count)
                {
                    photos[i].transform.parent.gameObject.SetActive(true);
                    var film = photos[i].GetComponent<PhotoFilm>();
                    film.eventData = captureEvents[i]; 
                    film.ResetPhotoFilm();
                }
                else
                    photos[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
