## CLI 협업 1. 수업 소개 
* 복습 & 협업
	- git clone 원격 저장소 주소
	- git clone 복사한 주소 붙여넣기 git_home
	* git clone 복사한 주소 붙여넣기 git_office
	* git log
	* cd ~
	* git remote -v : 원격 저장소를 복제하면 자동으로 지역 저장소와 원격 저장소가 연결됨.
	* git commit -am "메세지": 스테이징과 커밋 한꺼번에 사용 가능.
	* cd ~/git_office 
	* git pull
	* git commit -am "message"
	* git push
	* cd ~/git_home
	* git pull
	* git log
* 원격 브랜치 정보 가져오기
	- 원격 master 브랜치
	- cd ~/git_home
	- git log --oneline
	- vim 파일.txt -> git add 파일.txt -> git commit -m "메시지"
	- git log --oneline 명령으로 커밋 로그 확인
	- git status로  버전확인
* 원격 브랜치 정보 가져오기 - git fetch
	- 'fetch' 불러오다. 가져오다. 
	- git fetch 명령은 원격 저장소의 정보를 가져오는 기능 vs git pull이 원격 저장소의 커밋을 가져와서 무조건 지역 저장소와 합친다면, fetch 명령은 원격 브랜치에 어떤 변화 있는지 그 정보만 가져옴.
	- 팀 작업시 다른 사람이 수정한 소스를 한번 더 훑고 지역 저장소와 합치고 싶다면 pull 대신 fetch 사용해서 커밋을 가져온 다음 지역 저장소와 합치면 됨. 
	- cd ~/git_office
	- git fetch
	- git checkout FETCH_HEAD
	- git checkout master
	- git merge FETCH_HEAD
	- fetch한 후에 최신 커밋을 현재 브랜치에 합치려면 git pull 명령 사용해서 원격 저장소의 소스를 내려받을 수도 있고, git merge 명령으로 FETCH_HEAD에 있던 커밋을 병합할 수도 있음. 
		- git checkout master
		- git merge FETCH_HEAD
		- git pull 명령은 git fetch 명령과 git merge FETCH_HEAD 명령 두 개를 합친 것과 같은 기능을 함. 
	- git merge origin/master
	- git merge origin/브랜치 이름
	- git merge FETCH_HEAD
