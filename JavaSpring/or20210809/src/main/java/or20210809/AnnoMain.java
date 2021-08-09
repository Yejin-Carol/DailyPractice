package or20210809;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class AnnoMain {
	public static void main(String[] args) {
		
		AnnotationConfigApplicationContext acac = new AnnotationConfigApplicationContext(AnnoConf.class, AnnoConf.class);
		
		RM rm1 = acac.getBean(RM.class);
		RM rm2 = acac.getBean(RM.class);
		JK jk = acac.getBean(JK.class);
		
		System.out.println(rm1);
		System.out.println(rm2);
		System.out.println(jk);
		
		acac.close();
	}

	
}
