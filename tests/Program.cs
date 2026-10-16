using System.Reflection;
using System.Runtime.Loader;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Maestro.BrainiacCollectibles;
var runtime=Environment.GetEnvironmentVariable("SPT_ROOT")??throw new Exception("Set SPT_ROOT");
AssemblyLoadContext.Default.Resolving+=(c,n)=>{var p=Path.Combine(runtime,n.Name+".dll");return File.Exists(p)?c.LoadFromAssemblyPath(p):null;};
Checks.Run();
static class Checks {
 [MethodImpl(MethodImplOptions.NoInlining)]public static void Run(){
 int passed=0;
 void Check(bool condition,string name){if(!condition)throw new Exception(name);passed++;}
 var entries=JsonSerializer.Deserialize<List<Collectible>>(File.ReadAllText("content/catalogue.json"),new JsonSerializerOptions{PropertyNameCaseInsensitive=true})!;
 var root=Path.Combine(Path.GetTempPath(),"brainiac-locales-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(Path.Combine(root,"locales"));
 try{
 foreach(var p in Directory.EnumerateFiles("content/locales","*.json"))File.Copy(p,Path.Combine(root,"locales",Path.GetFileName(p)));
 var localized=ItemLocalization.Load(root,entries);
 var codes=new[]{"en","ge","ru","po","ch","fr","es","es-mx","jp","kr","pl","cz","it","hu","ro","sk","tu"};
 Check(localized.Count==30,"All 30 items required");
 foreach(var e in entries){Check(localized[e.Slug].Keys.ToHashSet().SetEquals(codes),"Locale codes mismatch: "+e.Slug);foreach(var value in localized[e.Slug].Values){Check(!string.IsNullOrWhiteSpace(value.Name)&&!string.IsNullOrWhiteSpace(value.Description),"Missing item name/lore");Check(value.ShortName.Length<=22,"Short name too long");}}
 var path=Path.Combine(root,"locales/fr.json");var original=File.ReadAllText(path);File.Delete(path);bool rejected=false;try{ItemLocalization.Load(root,entries);}catch(FileNotFoundException){rejected=true;}Check(rejected,"Missing locale accepted");
 File.WriteAllText(path,"{}");rejected=false;try{ItemLocalization.Load(root,entries);}catch(InvalidDataException){rejected=true;}Check(rejected,"Incomplete locale accepted");
 File.WriteAllText(path,original);Check(ItemLocalization.Load(root,entries).Count==30,"Valid locale recovery failed");
 Console.WriteLine($"Passed: {passed}, Failed: 0. Native loader checked against local SPT assemblies; no game registration or profiles touched.");
 }finally{Directory.Delete(root,true);}
 }
}
