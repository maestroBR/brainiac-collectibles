using SPTarkov.Server.Core.Models.Spt.Mod;
namespace Maestro.BrainiacCollectibles;
public sealed class Metadata:IModMetadata {
 public string ModGuid{get;init;}="project.brainiac.collectibles";
 public string Name{get;init;}="Project Brainiac — Colecionáveis";
 public string Author{get;init;}="Maestro";
 public List<string>? Contributors{get;init;}=null;
 public SemanticVersioning.Version Version{get;init;}=new("1.4.0");
 public SemanticVersioning.Range SptVersion{get;init;}=new("=4.1.6");
 public bool HasPrepatcher{get;init;}=false;
 public List<string>? Incompatibilities{get;init;}=null;
 public Dictionary<string,SemanticVersioning.Range>? ModDependencies{get;init;}=null;
 public string? Url{get;init;}="https://github.com/maestroBR/brainiac-collectibles";
 public string License{get;init;}="MIT";
}
