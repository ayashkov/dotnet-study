using Microsoft.Build.Tasks;

namespace study.build;

public class CopyTask: Copy {
        public override bool Execute()
        {
            Log.LogWarning("From CopyTask");

            return base.Execute();
        }
}
