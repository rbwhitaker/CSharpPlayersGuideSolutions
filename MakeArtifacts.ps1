$tag = "";
if($args.Length -eq 0) { $tag = read-host -Prompt "Tag: "; }
else { $tag = $args[0]; }

if(Test-Path -Path Artifacts) { rmdir Artifacts -Recurse -Force }
mkdir Artifacts
git archive -o 5thEdition/Artifacts/AllSolutions.zip $tag :'5thEdition'
git archive -o 5thEdition/Artifacts/FinalBattleExpansionPathStart.zip $tag :'5thEdition/Level52-TheFinalBattle/00-ExpansionPath-START HERE'
git archive -o 5thEdition/Artifacts/FinalBattleFinal.zip $tag  :'5thEdition/Level52-TheFinalBattle/00-TheFinalBattle-FINAL VERSION'
git archive -o 5thEdition/Artifacts/FountainOfObjectsFinal.zip $tag :'5thEdition/Level31-TheFountainOfObjects/CombinedGame'