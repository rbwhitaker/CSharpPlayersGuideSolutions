if(Test-Path -Path Artifacts) { rmdir Artifacts -Recurse -Force }
mkdir Artifacts
git archive -o Artifacts/AllSolutions.zip HEAD
git archive -o Artifacts/FinalBattleExpansionPathStart.zip HEAD:'Level52-TheFinalBattle/00-ExpansionPath-START HERE'
git archive -o Artifacts/FinalBattleFinal.zip HEAD:'Level52-TheFinalBattle/00-TheFinalBattle-FINAL VERSION'
git archive -o Artifacts/FountainOfObjectsFinal.zip HEAD:'Level31-TheFountainOfObjects/CombinedGame'