package com.yj.member.service;

import org.springframework.beans.factory.annotation.Autowired;

import com.yj.member.Member;
import com.yj.member.dao.MemberDao;

public class MemberSearchService {

	@Autowired
	private MemberDao memberDao;
	
	public MemberSearchService() {}
	
	public Member searchMember (String mId) {
		return memberDao.select(mId);
	}
}
