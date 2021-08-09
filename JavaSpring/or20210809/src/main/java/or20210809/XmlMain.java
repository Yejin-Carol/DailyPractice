package or20210809;

import org.springframework.context.support.GenericXmlApplicationContext;

public class XmlMain {

	public static void main(String[] args) {
		GenericXmlApplicationContext gxac = new GenericXmlApplicationContext("classpath:XmlConf.xml");
		
		RM rm1 = gxac.getBean(RM.class);
		RM rm2 = gxac.getBean(RM.class);
		JK jk = gxac.getBean(JK.class);
		
		System.out.println(rm1);
		System.out.println(rm2);
		System.out.println(jk);
		
		System.out.println(rm1.getRmm());
		rm1.setRmm(200);
		System.out.println(rm2.getRmm());

		System.out.println(jk.getRm().getRmm());
	}

}
