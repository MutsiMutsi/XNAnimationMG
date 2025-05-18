// See https://aka.ms/new-console-template for more information
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using XNAnimationPipeline.Pipeline;


public class TestLogger : ContentBuildLogger
{
	public override void LogImportantMessage(string message, params object[] messageArgs)
	{
		Console.WriteLine(message);
	}

	public override void LogMessage(string message, params object[] messageArgs)
	{
		Console.WriteLine(message);
	}

	public override void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, params object[] messageArgs)
	{
		Console.WriteLine(message);
	}
}

public class TestImpCtx : ContentImporterContext
{
	public override string IntermediateDirectory => "";

	public override ContentBuildLogger Logger => new TestLogger();

	public override string OutputDirectory => "";

	public override void AddDependency(string filename)
	{
		throw new NotImplementedException();
	}
}

public class TestProcCtx : ContentProcessorContext
{
	public override string BuildConfiguration => "";

	public override string IntermediateDirectory => "";

	public override ContentBuildLogger Logger => new TestLogger();

	public override ContentIdentity SourceIdentity => default;

	public override string OutputDirectory => "";

	public override string OutputFilename => "";

	public override OpaqueDataDictionary Parameters => default;

	public override TargetPlatform TargetPlatform => TargetPlatform.DesktopGL;

	public override GraphicsProfile TargetProfile => GraphicsProfile.HiDef;

	public override void AddDependency(string filename)
	{
		throw new NotImplementedException();
	}

	public override void AddOutputFile(string filename)
	{
		throw new NotImplementedException();
	}

	public override TOutput BuildAndLoadAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName)
	{
		throw new NotImplementedException();
	}

	public override ExternalReference<TOutput> BuildAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName, string assetName)
	{
		throw new NotImplementedException();
	}

	public override TOutput Convert<TInput, TOutput>(TInput input, string processorName, OpaqueDataDictionary processorParameters)
	{
		return default;
	}
}

public class Program
{
	public static void Main()
	{
		ArcturusModelImporter imp = new ArcturusModelImporter();
		var model = imp.Import(@"C:\Users\mitch\Documents\Repositories\Arcturus\Arcturus\Arcturus\Content\worm.fbx", new TestImpCtx());


		SkinnedModelProcessor proc = new SkinnedModelProcessor();
		var processed = proc.Process(model, new TestProcCtx());
	}
}