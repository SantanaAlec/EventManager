using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EventManager.Desktop.Api.Entities;

public class Room
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("updatedDate")]
    public DateTime UpdatedDate { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public RoomType Type { get; set; }

    [JsonPropertyName("events")]
    public List<Event> Events { get; private set; } = new();

    public enum RoomType
    {
        [EnumMember(Value = "room")]
        Room,

        [EnumMember(Value = "auditorium")]
        Auditorium
    }
}