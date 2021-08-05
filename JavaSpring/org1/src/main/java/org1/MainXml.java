package org1;

import org.springframework.context.support.GenericXmlApplicationContext;

public class MainXml {

	public static void main(String[] args) {
		GenericXmlApplicationContext gxac =
				new GenericXmlApplicationContext("classpath:xmlConf.xml");
		
		MemberService ms = gxac.getBean(MemberService.class);
		ms.insert("RM", 10);
		ms.insert("지민", 20);
		ms.dolist();
		
		gxac.close();

	}

}
