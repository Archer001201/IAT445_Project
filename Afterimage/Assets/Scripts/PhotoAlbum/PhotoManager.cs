using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhotoAlbum
{
    public class PhotoManager : MonoBehaviour
    {
        public List<CaptureEventAndMaterial> levelOne;
        public List<GameObject> photos;

        private void Start()
        {
            AssignEventAndMaterial();
        }

        public void AssignEventAndMaterial()
        {
            for (var i = 0; i < photos.Count; i++)
            {
                if (i < levelOne.Count)
                {
                    photos[i].transform.parent.gameObject.SetActive(true);
                    var film = photos[i].GetComponent<PhotoFilm>();
                    film.eventAndMaterial = levelOne[i]; 
                    film.ResetPhotoFilm();
                }
                else
                    photos[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
