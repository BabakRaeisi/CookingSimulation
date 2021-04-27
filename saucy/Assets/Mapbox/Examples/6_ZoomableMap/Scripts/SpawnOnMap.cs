namespace Mapbox.Example
{
    using UnityEngine;
    using Mapbox.Utils;
    using Mapbox.Unity.Map;
    using Mapbox.Unity.MeshGeneration.Factories;
    using Mapbox.Unity.Utilities;
    using System.Collections.Generic;

    public class SpawnOnMap : MonoBehaviour
    {
        [SerializeField]
        AbstractMap _map;
        public string location_str; 
        [SerializeField]
        [Geocode]
        string[] _locationStrings;
        Vector2d[] _locations;
        Vector2d[] Loco;
        [SerializeField]
        float _spawnScale = 100f;

        [SerializeField]
        GameObject _markerPrefab;
        public GameObject instant_pin;

        List<GameObject> _spawnedObjects;
        GameObject[] _spawnObjects = new GameObject[1];

        void Start()
        {


            _locations = new Vector2d[_locationStrings.Length];
            _spawnedObjects = new List<GameObject>();

            _locations = new Vector2d[_locationStrings.Length];
            for (int i = 0; i < _locationStrings.Length; i++)
            {
                var locationString = _locationStrings[i];
                _locations[i] = Conversions.StringToLatLon(locationString);
                var instance = Instantiate(_markerPrefab);
                instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
                instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                _spawnedObjects.Add(instance);
            }
        }

        private void Update()
        {
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnedObjects[i];
                var location = Loco[i];
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);

            }
            instant_pin.transform.localPosition = _map.GeoToWorldPosition(pin_loc, true);
            instant_pin.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);


        }
        Vector2d pin_loc = new Vector2d();
        bool PinExist = true;
        public void Set_marker(Vector2d pin)
        {
            if (PinExist)
            {
                pin_loc = pin;
                instant_pin = Instantiate(_markerPrefab);

                instant_pin.transform.localPosition = _map.GeoToWorldPosition(pin);
                instant_pin.transform.localScale = new Vector3(2f, 2f, 2f);
                PinExist = false;
                PlayerPrefs.SetString("location", pin_loc.ToString());
                location_str = PlayerPrefs.GetString("location"); 
            }
            else
            {
                pin_loc = pin;
                GameObject instant_clone = GameObject.Find("MapboxPin(Clone)");
                Destroy(instant_clone);

                instant_pin = Instantiate(_markerPrefab);

                instant_pin.transform.localPosition = _map.GeoToWorldPosition(pin);
                instant_pin.transform.localScale = new Vector3(2f, 2f, 2f);
                PlayerPrefs.SetString("location", pin_loc.ToString());
                location_str = PlayerPrefs.GetString("location");


            }
            // Loco[0] = Conversions.StringToLatLon(Pin);
            // var instant_pin = Instantiate(_markerPrefab);
            //
            //
            //  instant_pin.transform.localPosition = _map.GeoToWorldPosition(Loco[0], true);
            //  instant_pin.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            //
            //  _spawnedObjects.Add(instant_pin);
            //


        }




    }

}