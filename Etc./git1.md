## 2. 깃으로 버전 관리하기
* 깃 저장소 만들기
	- 깃 초기화하기 -git init
$ git 
$ mkdir hello-git
$ git init : initialize repository
	- git 디렉터리는 감춰져 있음. 숨긴 항목에서 확인 가능
* 버전 만들기
	- Working tree / Staging Area / Repository
	- Working tree (작업트리): 파일 수정, 저장 등의 작업함. = working directory. 즉, hello-git 디렉터리에 해당 (눈에 보이는 디렉터리)
	- Staging Area (스테이지): 버전으로 만들 파일이 대기하는 곳. 작업 트리 10개 파일 수정시 파일 3개만 버전으로 만들려면 해당 파일 3개만 스테이지로 넘겨줌.
	- Repository (저장소): 스테이지와 저장소는 눈에 보이지 않음. 깃 초기화시 .git 디렉터리 안에 숨은 파일 형태로 존재하는 영역. commit 명령 내리면 새로운 버전이 생성되면서 스테이지에 대기하던 파일이 모두 저장소에 저장됨. 
	-	Working tree에 Vim으로 수정하기
		- 1) vim에서 파일 생성 후 :wq 나와서 git status 확인하면 untracked files 확인 가능, untracked files (한번도 버전 관리하지 않은 파일)
		- .git: git repository
		- git status: working tree status
		- warning 메시지: 깃 명령 리눅스 기반으로 윈도우 줄바꿈 문자와 리눅스 줄바꿈 문자 다름. eol(end of line) 혹은 개행문자 CRLF 문자 사용. 리눅스와 맥에서는 LF 삽입 됨. 따라서 윈도우즈에 warning: LF will be replaced by CRLF 같은 경고 메시지 나타남. 
		- 2) git add (add to staging area)후, git status확인하면 changes to be commited:로 바뀜 (working tree -> staging area로)
		- 3) git commit: create version -> 보통 git commit -m "메세지 내용" (stating area -> repository)
		- git commit -am (스테이징과 커밋 한꺼번에 처리)

* 커밋 내용 확인하기
	- 커밋 기록 자세히 살펴보기 
		- git log: show version
		- commit 옆에 긴 문자열 (commit hash 혹은 git hash, 커밋을 구별하는 아이디)
		- (HEAD -> master) 최신버전
	- 변경 사항 확인하기 
		- 파일 수정 후, git status에 Changes not staged for commit:, modified: 파일명
		- git diff: show changes (+삽입, -삭제된거 확인 가능)
* 버전 만드는 단계마다 파일 상태 알아보기
	- tracked 파일과 untracked 파일
		- Changes not staged for commit (변경된 파일이 아직 스테이지에 올라가지 않음, modifield 파일 수정). 깃은 한번이라도 커밋을 한 파일의 수정 여부를 계속 추적함. -> tracked
		- 새로 생성한 파일은 기록 없으므로 untracked files
		- git add . (변경된 모든 파일 staging area로)
		- git log --stat (커밋에 관련된 파일까지 함께 살펴보기)
		- .gitignore 파일로 버전 관리에서 제외하기
	- unmodified, modified, staged 상태
		- Changes not staged for commit: unmodified
		- Changes to be commited: staged
		- nothing to commit, working tree clean: unmodified
	- 방금 커밋한 메시지 수정: git commit --amend

* 작업 되돌리기
	- working tree에서 수정한 파일 되돌리기 - git checkout
		- use git checkout -- \<file>... "to discard changes in working directory
	- 스테이징 되돌리기 - git reset HEAD 파일 이름
		- Unstaged changes after reset: 
		- git reset HEAD^ : 최신 커밋 되돌리기 (커밋도 취소되고 스테이지도 내려짐)
		- 
| 명령 | 설명  |
|--|--|
|--soft HEAD^ | 최근 커밋을 하기 전 상태로 작업 트리 되돌림 |
|--mixed HEAD^ | 최근 커밋과 스테이징 하기 전 상태로 작업 트리를 되돌림. 옵션 없이 git rest 명령을 사용할 경우 이 옵션을 기본으로 작동함 |
| --hard HEAD^ | 최근 커밋과 스테이징, 파일 수정을 하기 전 상태로 작업 트리를 되돌림. 이 옵션으로 되돌린 내용은 복구할 수 없음. |

* 특정 커밋으로 되돌리기 - git resert 커밋 해시
	- git reset --hard 커밋 해시: HEAD is now at ~~최신 커밋이 됨. git log로 확인. 즉, 지장한 커밋 해시로 이동하고 이후 커밋은 취소함.
*  커밋 삭제하지 않고 되돌리기 -git revert 커밋 해시
	- 기본 편집기가 나타나면서 커밋 메시지 입력 가능. 즉 지정한 커밋 해시의 변경 이력을 취소함.
* git log -p: 이때까지 log들 어떤 것들이 바꼈는지 확인
 
