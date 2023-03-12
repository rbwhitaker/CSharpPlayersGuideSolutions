$tag = "";
if($args.Length -eq 0) { $tag = read-host -Prompt "Tag: "; }
else { $tag = $args[0]; }

if(Test-Path -Path Artifacts) { rmdir Artifacts -Recurse -Force }
mkdir Artifacts
git archive -o Artifacts/AllSolutions.zip $tag :'5thEdition'
git archive -o Artifacts/FinalBattleExpansionPathStart.zip $tag :'5thEdition/Level52-TheFinalBattle/00-ExpansionPath-START HERE'
git archive -o Artifacts/FinalBattleFinal.zip $tag  :'5thEdition/Level52-TheFinalBattle/00-TheFinalBattle-FINAL VERSION'
git archive -o Artifacts/FountainOfObjectsFinal.zip $tag :'5thEdition/Level31-TheFountainOfObjects/CombinedGame'