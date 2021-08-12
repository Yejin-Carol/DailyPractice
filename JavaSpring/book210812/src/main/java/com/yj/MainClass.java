package com.yj;

import org.springframework.context.support.GenericXmlApplicationContext;

import com.yj.book.Book;
import com.yj.book.service.BookRegisterService;
import com.yj.book.service.BookSearchService;
import com.yj.member.Member;
import com.yj.member.service.MemberRegisterService;
import com.yj.member.service.MemberSearchService;

public class MainClass {

	public static void main(String[] args) {
		
		String[] bNums = {"789", "123", "456", "987", "321"};
		String[] bTitles = {"html", "css", "jQuery", "java", "spring"}; 
		
		String[] mIds = {"rabbit", "hippo", "sloth", "raccon", "lion"};
		String[] mPws = {"11111", "22222", "33333", "44444", "55555"};
		String[] mNames = {"Christ", "Sarah", "Mike", "Julie", "Andy"};
		
		//스프링 컨테이너 생성
		GenericXmlApplicationContext gxac = 
				new GenericXmlApplicationContext("classpath:appCtx.xml");
		
		//더미 도서 목록 등록
		BookRegisterService bookRegisterService = 
				gxac.getBean("bookRegisterService", BookRegisterService.class);		
		
		for(int i=0; i<bNums.length; i++) {
			Book book = new Book(bNums[i], bTitles[i], true, null);
			bookRegisterService.register(book);
		}
		
		//더미 도서 목록 출력
		BookSearchService bookSearchService =
				gxac.getBean("bookSearchSerivce", BookSearchService.class);
		System.out.println("\nbNum\tbTitle\tbCanRen\tbLenderId");
		System.out.println("-----------------------------------");
		for (int i = 0; i < bNums.length; i++) {
			Book book = bookSearchService.searchBook(bNums[i]);
			System.out.println(book.getbNum()+"\t");
			System.out.println(book.getbTitle()+"\t");
			System.out.println(book.isbCanRental()+"\t");
			System.out.println(book.getbMember() == null ? null : book.getbMember().getmId());
		}
		
		//더미 회원 목록 등록
		MemberRegisterService memberRegisterService =
				gxac.getBean("memberRegisterService", MemberRegisterService.class);
		for(int i=0; i<mIds.length; i++) {
			Member member = new Member(mIds[i], mPws[i], mNames[i]);
			memberRegisterService.register(member);
		}
		
		//더미 회원 목록 출력
		MemberSearchService memberSearchService =
				gxac.getBean("memberSearchService", MemberSearchService.class);
		System.out.println("\nbNum\tbTitle\tbCanRen\tbLenderId");
		System.out.println("-------------------------------------");
		for (int i=0; i <bNums.length; i++) {
			Book book = bookSearchService.searchBook(bNums[i]);
			System.out.println(book.getbNum()+"\t");
			System.out.println(book.getbTitle()+"\t");
			System.out.println(book.isbCanRental()+"\t");
			System.out.println(book.getbMember() == null ? null : book.getbMember().getmId());
		}
		
		//도서 대여 목록 등록
		bookRegisterService.register(new Book("789", "html", false, memberSearchService.searchMember("rabbit")));
		bookRegisterService.register(new Book("123", "css", false, memberSearchService.searchMember("hippo")));
		bookRegisterService.register(new Book("456", "jQuery", false, memberSearchService.searchMember("sloth")));
		bookRegisterService.register(new Book("987", "java", false, memberSearchService.searchMember("raccon")));
	
		//도서 대여 목록 출력
		System.out.println("\nbNum\tbTitle\tbCanRen\tbLenderId");
		System.out.println("-------------------------------------");
		for (int i=0; i <bNums.length; i++) {
			Book book = bookSearchService.searchBook(bNums[i]);
			System.out.println(book.getbNum()+"\t");
			System.out.println(book.getbTitle()+"\t");
			System.out.println(book.isbCanRental()+"\t");
			System.out.println(book.getbMember() == null ? null : book.getbMember().getmId());
		}
		
	
	}

		
		
	
}
