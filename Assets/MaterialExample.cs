using System;
using MaterialUI;
using Properties;
using UnityEngine;

namespace DefaultNamespace
{
    public class MaterialExample : MonoBehaviour
    {
        private void Start()
        {
            ResourceManager.LoadImages();
            
            MaterialUISettings.Theme = MaterialThemes.Light;
            
            new FormMaterial().Show();

            MaterialUISettings.Theme = MaterialThemes.Dark;
            
            new FormMaterial().Show();
        }
    }
}