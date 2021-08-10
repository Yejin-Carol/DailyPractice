package org20210810;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class MainForAnno {

	public static void main(String[] args) {
		AnnotationConfigApplicationContext acac = new AnnotationConfigApplicationContext(AnnoConf.class);

		Lib lib = acac.getBean(Lib.class);
		lib.print();
		
		acac.close();
	}

}
