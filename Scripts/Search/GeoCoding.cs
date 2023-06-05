using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Json;
using Mapbox.Utils.JsonConverters;
using Mapbox.Geocoding;
using Mapbox.Examples;

public class Geocoding : MonoBehaviour
{
    [SerializeField]
    GeocodingInput _searchLocation;

    [SerializeField]
    Text _resultsText;

    void Awake()
    {
        _searchLocation.OnGeocoderResponse += SearchLocation_OnGeocoderResponse;
    }

    void OnDestroy()
    {
        if (_searchLocation != null)
        {
            _searchLocation.OnGeocoderResponse -= SearchLocation_OnGeocoderResponse;
        }
    }

    void SearchLocation_OnGeocoderResponse(ForwardGeocodeResponse response)
    {
        _resultsText.text = JsonConvert.SerializeObject(_searchLocation.Response, Formatting.Indented, JsonConverters.Converters);
    }
}