using Microsoft.Build.Tasks;

namespace study.build;

public class FilteredCopy: Copy {
    public override bool Execute()
    {
        Log.LogWarning("From FilteredCopy");

        return base.Execute();
    }
}
