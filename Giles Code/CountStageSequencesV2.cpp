#include <stdio.h>
#include <stdlib.h>

#include <vector>

const int nMinGreen = 7;
const int nIntergreen = 5;

const int nStages = 3;

const int nIncrement = 1;

typedef int stage_t;

struct CStageEvent
{
public:
    CStageEvent() : iStage(0), nRunTime(0) {}
    stage_t iStage;
    int nRunTime;
};

typedef std::vector<CStageEvent> StagePattern_t;

static FILE* out;

static void traverseStages(int remainingTime, stage_t currentStage, stage_t startStage, __int64& nPatterns, StagePattern_t& pattern, int iPattern) {
    while (remainingTime >= nIntergreen)
    {
        for (int iStage = 1; iStage <= nStages; iStage++)
        {
            if (iStage != currentStage)
            {
                pattern[iPattern].iStage = 0;
                pattern[iPattern].nRunTime = nIntergreen;
                pattern[iPattern+1].iStage = iStage;
                pattern[iPattern+1].nRunTime = nMinGreen;

                traverseStages(remainingTime - nIntergreen - nMinGreen, iStage, startStage, nPatterns, pattern, iPattern+2);
            }
        }

        pattern[iPattern-1].nRunTime += nIncrement;

        remainingTime -= nIncrement;
    }

    // Discard patterns where the start of the next cycle cannot start with the same stage.
    if (currentStage != startStage) return;

    // Correct for under or over run.
    pattern[iPattern-1].nRunTime += remainingTime;
    while (pattern[iPattern-1].nRunTime <= 0)
    {
        iPattern--;
        pattern[iPattern-1].nRunTime += pattern[iPattern].nRunTime;
    }

    // Print out this sequence
    for (int i = 0; i < iPattern; i++)
    {
        fprintf(out, "%c,%d,", pattern[i].iStage == 0 ? '-' : pattern[i].iStage + 'A' - 1, pattern[i].nRunTime);
    }
    fputc('\n', out);

    nPatterns++;
}

int main(int argc, char* argv[])
{
    __int64 nPatterns = 0;
    const char szOutputFile[] = "output.csv";

    int nCycleTime = 60;
    int nMaxChanges = (nCycleTime / (nMinGreen + nIntergreen) + 1) * 2;

    StagePattern_t pattern(nMaxChanges);

    if (fopen_s(&out, szOutputFile, "w") != 0)
    {
        perror(szOutputFile);
        exit(EXIT_FAILURE);
    }

    // Print CSV column headings.
    for (int i = 0; i < nMaxChanges; i++)
    {
        fputs("Stage,Run Time,", out);
    }
    fputc('\n', out);

    for (stage_t iStage = 1; iStage <= nStages; iStage++)
    {
        pattern[0].iStage = iStage;
        pattern[0].nRunTime = nMinGreen;
        traverseStages(nCycleTime - nMinGreen, iStage, iStage, nPatterns, pattern, 1); 
    }

    printf("Number of possible stage sequences: %lld\n", nPatterns); } 
