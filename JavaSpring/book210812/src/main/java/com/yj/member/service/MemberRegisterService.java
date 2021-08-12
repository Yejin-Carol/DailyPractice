package com.yj.member.service;

import org.springframework.beans.factory.annotation.Autowired;

import com.yj.member.Member;
import com.yj.member.dao.MemberDao;

public class MemberRegisterService {

	@Autowired
	private MemberDao memberDao;
	
	public MemberRegisterService() {}
	
	public void register(Member member) {
		memberDao.insert(member);
	}
	
	public void initMethod() {
		System.out.println("--initMethod()--");
	}
	
	public void destroyMethod() {
		System.out.println("--destroyMethod()--");
	}
	
	
}
