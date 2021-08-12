package com.yj.book.service;

import org.springframework.beans.factory.DisposableBean;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.beans.factory.annotation.Autowired;

import com.yj.book.Book;
import com.yj.book.dao.BookDao;

public class BookSearchService implements InitializingBean, DisposableBean {

	@Autowired
	private BookDao bookDao;
	
	public BookSearchService() {}
	
	public Book searchBook(String bNum) {
		Book book = bookDao.select(bNum);
		return book;
	}

	@Override
	public void destroy() throws Exception {
		System.out.println("object create");
		
	}

	@Override
	public void afterPropertiesSet() throws Exception {
		System.out.println("object dispose");
		
	}
	
	
}
