package org;

import org.springframework.context.support.GenericXmlApplicationContext;

public class MainXmlConfig {

	public static void main(String[] args) {
		GenericXmlApplicationContext gxac
			= new GenericXmlApplicationContext("classpath:myconf.xml");
		AA a1= gxac.getBean(AA.class);
		AA a2= gxac.getBean(AA.class);
		
		System.out.println(a1);
		System.out.println(a2);
		
		System.out.println(a1==a2?"true":"false");
		
		
		gxac.close();
		
	}
}
