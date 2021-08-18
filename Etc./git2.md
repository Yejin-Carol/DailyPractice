## 3. 깃과 브랜치
* git branch 브랜치명 : 브랜치 생성
* git log --oneline : --online 옵션은 한 줄에 한 커밋씩 나타내 주기 때문에 커밋을 간략히 확인할 때 편리함.
* git log --oneline --branches: 브랜치 커밋 함께 볼 수 있음
* git log --oneline --branches --graph : 브랜치와 커밋 관계 더 보기 쉽게 그래프 형태로 표시함.
* git log mater ..브랜치명 : master 브랜치와 해당 브랜치 사이의 차이점
* git checkout master 
* git merge 브랜치명 
* 병합 및 충돌 해결 프로그램: P4Merge/Meld/Kdiff3/Araxis Merge
* git branch -d 브랜치명: 해당 브랜치 삭제, (-D 대문자 강제로 브랜치 삭제)
* git resert 커밋 해시: 현재 브랜치가 가리키는 커밋을 여러 브랜치 사이를 넘나들면서 제어할 수 있음.
* 수정 중인 파일 감추기 및 되돌리기 - git stash
* git stash list
* git stash pop : stash 목록에서 가장 최근 항목을 되돌림.
* git stash apply: stash 목록에 저장된 수정 내용 나중에 또 사용할지 모른다면
* git stash drop: stash 목록에서 가장 최근 항목 삭제함.
