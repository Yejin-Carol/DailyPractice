package org1;

import java.util.ArrayList;

public class MemberService {

	public static ArrayList<Member> member_list = new ArrayList<Member>();

	//등록
	public void insert(String name, int age) {
		Member member = new Member();
		member.setName(name);
		member.setAge(age);
		member_list.add(member);
	}
	// 내용 보여주기
	public void dolist() {
		System.out.println("----member list 내용 시작----");
		for(Member member:member_list) {
			System.out.println(member);			
		}
		System.out.println("----member list 내용 끝----");
	}

}
