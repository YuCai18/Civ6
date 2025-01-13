using Godot;

namespace ProceduralPlanet.Scripts.Planet.Settings.NoiseSettings;

[Tool]
[GlobalClass]
public partial class SimplexNoiseSettings : Resource
{
    private int _numLayers = 4;

    [Export]
    public int NumLayers
    {
        get => _numLayers;
        set
        {
            _numLayers = value;
            EmitChanged();
        }
    }

    private float _lacunarity = 2f;

    [Export]
    public float Lacunarity
    {
        get => _lacunarity;
        set
        {
            _lacunarity = value;
            EmitChanged();
        }
    }

    private float _persistence = 0.5f;

    [Export]
    public float Persistence
    {
        get => _persistence;
        set
        {
            _persistence = value;
            EmitChanged();
        }
    }

    private float _scale = 1f;

    [Export]
    public float Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            EmitChanged();
        }
    }

    private float _elevation = 1f;

    [Export]
    public float Elevation
    {
        get => _elevation;
        set
        {
            _elevation = value;
            EmitChanged();
        }
    }

    private float _verticalShift = 0f;

    [Export]
    public float VerticalShift
    {
        get => _verticalShift;
        set
        {
            _verticalShift = value;
            EmitChanged();
        }
    }

    private Vector3 _offset = Vector3.Zero;

    [Export]
    public Vector3 Offset
    {
        get => _offset;
        set
        {
            _offset = value;
            EmitChanged();
        }
    }

    public float[] GetNoiseParams(RandomNumberGenerator rng)
    {
        var seededOffset = new Vector3(rng.Randf(), rng.Randf(), rng.Randf()) * rng.Randf() * 10000f;
        var noiseParams = new[]
        {
            // 0
            seededOffset.X + _offset.X,
            seededOffset.Y + _offset.Y,
            seededOffset.Z + _offset.Z,
            _numLayers,
            // 1
            _persistence,
            _lacunarity,
            _scale,
            _elevation,
            // 2
            _verticalShift,
            0f, 0f, 0f
        };
        return noiseParams;
    }
}