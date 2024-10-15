using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PhotoAlbum
{
    public class PhotoManager : MonoBehaviour
    {
        public List<CaptureEventAndMaterial> levelBedroom;
        public List<GameObject> photos;

        private void Start()
        {
            AssignEventAndMaterial();
        }

        public void AssignEventAndMaterial()
        {
            for (var i = 0; i < photos.Count; i++)
            {
                if (i < levelBedroom.Count)
                {
                    photos[i].transform.parent.gameObject.SetActive(true);
                    var film = photos[i].GetComponent<PhotoFilm>();
                    film.eventAndMaterial = levelBedroom[i]; 
                    film.ResetPhotoFilm();
                }
                else
                    photos[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
