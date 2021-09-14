
## 깃허브로 백업하기
### [동준쌤이랑 수업했던 것 정리 참고](https://blog.naver.com/felizcarol/222438098844)

* Local Repository -> PUSH -> Remote Repository
*  Remote Repository -> Clone -> Local Repository
* Remote Repository -> PULL -> Local Repository
* Local Repository -> PUSH -> Remote Repository....
* Git hosting: 원격 저장소. GitHub, GitLab 등
* Git hub 레포지토리 생성후
	- git init 원하는 지역저장소 디렉토리
	- cd 디렉토리
	- vim으로 .txt 파일 생성/add/commit/log
	- git remote add origin 깃허브 레포지토리 주소 붙여넣기
	- git remote -v : 원격 저장소 연결 확인
	- git push -u origin master : 지역 저장소 브랜치를 origin, 즉 원격 저장소의 master 브랜치로 푸시하는 명령. '-u' 옵션은 지역 저장소의 브랜치를 원격 저장소의 master 브랜치에 연결하기 위한 것으로 처음 한번만 사용
	- git push --set-upstream origin master: 위에 내용 이거랑 같은 듯, 최조 push할 때 설정해주는 것
	- 원격 저장소 내려 받기 git pull origin master
* 깃허브 저장소 화면
	- Unwatch: 이 저장소의 알림 내용 받아보기
	- Star: 이 저장소 즐겨찾기. Star 높을수록 사용자 많음
	- Fork: 저장소 복사. 깃허브 오픈 소스 프로젝트 참여하거나 직접 소스를 분석하면서 공부하려면 저장소 복제해야함.
* 깃허브에 SSH 원격 접속하기
	- SSH: Secure Shell: 보안이 강화된 안전한 방법으로 정보를 교환하는 방식. Private Key와 Public Key를 한 쌍으로 묶어서 컴퓨터를 인증함. 
	- 보통 웹 브라우저에서 깃허브 저장소에 접속할 때나 Source Tree 같은 프로그램을 사용해 깃허브 저장소에 접속할 때 사용하지만 SSH 원격 접속은 프라이빗 키와 퍼블릭 키를 사용해 현재 사용하고 있는 기기를 깃허브에 인증하는 방식임. 즉, 개인 노트북으로 접속한다면 노트북을 깃허브에 등록 혹은 서버 환경에서 접속한다면 서버 자체를 깃허브에 등록. SSH 접속 방법 사용하면 자동 로그인 기능
* SSH 키 생성하기
	- ssh-keygen 
	- ~~ /id_rsa. 프라이빗 키 경호
	- ~~/id_rsa.pub 퍼블릭 키 경로
	- cd ~/.ssh,
	-  ls -la : .ssh 디렉터리에 저장되었는지 확인 후 그 안의 내용 확인
* 깃허브에 퍼블릭 키 전송
	- cd ~/.ssh
	- cat id_rsa.pub
	- ssh-rsa부터 문자열 끝까지 copy후
	- 깃허브 접속 오른쪽 Setting
	- SSH and GPG keys 클릭후 New SSH Key 누름
	- Title에 현재 등록하는 SSH 퍼블릭 키 알아보게 제목 붙임. Key에 복사한 퍼블릭키 Paste -> Add -> 비번 확인 후 Confirm 
	- SSH 키 만들었던 컴퓨터는 깃허브 저장소의 SSH 주소만 알고 있으면 로그인 없이 저장소 접속 가능 
	- New Repository -> SSH 주소 복사
	- cd ~
	- git init connect-ssh
	- cd connect-ssh
	- git remote add origin 복사한 SSH 주소 붙여넣기
	- 그후 push & pull~~
