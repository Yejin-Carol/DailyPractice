package com.yj.book.service;

import org.springframework.beans.factory.DisposableBean;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.beans.factory.annotation.Autowired;

import com.yj.book.Book;
import com.yj.book.dao.BookDao;

public class BookRegisterService implements InitializingBean, DisposableBean{

	@Autowired
	private BookDao bookDao;
	
	public BookRegisterService() {}
	
	public void register(Book book) {
		bookDao.insert(book);
	}

	@Override
	public void afterPropertiesSet() throws Exception {
		System.out.println("bean 객체 생성");
		
	}

	@Override
	public void destroy() throws Exception {
		System.out.println("bean 객체 생성");
		
	}
	
	
}
