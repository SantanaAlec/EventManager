using EventManager.Desktop.Api.Entities;
using EventManager.Desktop.Scenes.Autoload.Scripts;
using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Material = EventManager.Desktop.Api.Entities.Material;

namespace EventManager.Desktop.Scenes.CreateEventoSalon.Components.Scripts;

public partial class OptionButtonSeleccionarMaterial : OptionButton
{
    public override void _Ready()
    {
        ApiConnection apiConnection = GetNode<ApiConnection>("/root/ApiConnection");

        HttpRequest httpRequest = new HttpRequest();
        httpRequest.UseThreads = true;
        AddChild(httpRequest);
        httpRequest.RequestCompleted += HttpRequestCompleted;
        httpRequest.RequestCompleted += (result, code, strings, body) =>
        {
            RemoveChild(httpRequest);
            httpRequest.QueueFree();
        };

        string contentType = "application/json";
        string authToken = apiConnection.AuthDetails.AuthToken;
        string[] headers =
        {
            $"Content-Type: {contentType}",
            $"Authorization: Bearer {authToken}"
        };

        Error error = httpRequest.Request($"{apiConnection.Url}/materials", headers, HttpClient.Method.Get);

        if (error != Error.Ok)
        {
            GD.PushError("An error occurred in the HTTP request.");
        }
    }

    private void HttpRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
    {
        Json json = new Json();
        json.Parse(body.GetStringFromUtf8());

        Godot.Collections.Array responseArray = json.Data.AsGodotArray();
        Dictionary responseDictionary = json.Data.AsGodotDictionary();

        switch (responseCode)
        {
            case 200:
                GD.Print(responseArray);

                for (int i = 0; i < responseArray.Count; i++)
                {
                    Dictionary dictionaryItem = responseArray[i].AsGodotDictionary();

                    string dictionaryJson = Json.Stringify(dictionaryItem);

                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        Converters =
                        {
                            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                        },
                    };

                    Material material = JsonSerializer.Deserialize<Material>(dictionaryJson, options);

                    AddItem(material.Name, i);
                    SetItemMetadata(i, material.Id);
                }

                break;
            case 401:
                GD.Print(responseDictionary);
                break;
            case 404:
                GD.Print(responseDictionary);
                break;
            default:
                GD.Print(responseDictionary);
                break;
        }
    }
}