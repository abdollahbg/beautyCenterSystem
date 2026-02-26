using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

public class EmbeddedFontLoader : IDisposable
{
    private readonly Dictionary<string, (PrivateFontCollection collection, FontFamily family)> _fonts
        = new Dictionary<string, (PrivateFontCollection, FontFamily)>();
    private readonly List<string> _tempFiles = new List<string>();

    public void LoadFontFromResource(string resourceName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (var fontStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (fontStream == null) return;

            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, fontData.Length);

            string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".ttf");
            File.WriteAllBytes(tempFile, fontData);
            _tempFiles.Add(tempFile);

            var pfc = new PrivateFontCollection();
            pfc.AddFontFile(tempFile);

            if (pfc.Families.Length > 0)
            {
                FontFamily family = pfc.Families[0];
                if (!_fonts.ContainsKey(family.Name))
                    _fonts.Add(family.Name, (pfc, family));
            }
        }
    }

    public FontFamily GetFontFamily(string name)
    {
        return _fonts.TryGetValue(name, out var tuple) ? tuple.family : FontFamily.GenericSansSerif;
    }

    public void Dispose()
    {
        foreach (var tuple in _fonts.Values) tuple.collection?.Dispose();
        foreach (var file in _tempFiles) { try { if (File.Exists(file)) File.Delete(file); } catch { } }
        _fonts.Clear();
        _tempFiles.Clear();
    }
}