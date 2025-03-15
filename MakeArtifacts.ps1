$tag = "";
if($args.Length -eq 0) { $tag = read-host -Prompt "Tag: "; }
else { $tag = $args[0]; }

if (Test-Path -Path Artifacts) { rmdir Artifacts -Recurse -Force }
mkdir Artifacts

mkdir Artifacts/6thEdition
git archive -o Artifacts/6thEdition/AllSolutions.zip $tag :'6thEdition'
git archive -o Artifacts/6thEdition/FinalBattleExpansionPathStart.zip $tag :'6thEdition/Level52-TheFinalBattle/00-ExpansionPath-START HERE'
git archive -o Artifacts/6thEdition/FinalBattleFinal.zip $tag  :'6thEdition/Level52-TheFinalBattle/00-TheFinalBattle-FINAL VERSION'
git archive -o Artifacts/6thEdition/FountainOfObjectsFinal.zip $tag :'6thEdition/Level31-TheFountainOfObjects/CombinedGame'