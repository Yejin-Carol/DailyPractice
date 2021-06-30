#include <stdio.h>
#include <Windows.h>

int arr1[6][8] =
{ {97,78,56,67,96  },
{86,67,89,75,78  },
{89,98,87,59,90  },
{56,78,81,89,85  },
{98,79,90,89,95  }
};//1�б� ���� ����Ÿ
int arr2[6][8];
int i, j;
int sum1, sum2, sum3, sum4, avr1, avr2, avr3, avr4;
char grade;

void Array1(void)
{
	printf("<<1�б� ����>>\n");
	//�л��� ���� �հ�, ���
	
	for (i = 0; i < 4; i++)
	{
		sum1 = 0;

		for (j = 0; j < 5; j++)
		{
			sum1 += arr1[i][j];
		}
		arr1[i][5] = sum1;
		avr1 = sum1 / 5;
		arr1[i][6] = avr1;

		if (avr1 >= 90)
			grade = 'A';
		else if (avr1 >= 80 && avr1 < 90)
			grade = 'B';
		else if (avr1 >= 70 && avr1 < 80)
			grade = 'C';
		else if (avr1 >= 60 && avr1 < 70)
			grade = 'D';
		else
			grade = 'F';

		arr1[i][7] = grade;
	}
	//���� ���� �Է�, �հ�, ���
	for (i = 0; i < 5; i++)
	{
		sum2 = 0;
		for (j = 0; j < 4; j++)
		{
			sum2 += arr1[j][i];
		}
		arr1[4][i] = sum2;
		avr2 = sum2 / 4;
		arr1[5][i] = avr2;
	}
	//ShowAll
	printf("\n\n�̸�\t" "����\t" "����\t" "����\t" "��ȸ\t" "����\t" "�հ�\t" "���\t" "���\n\n");
	for (i = 0; i < 6; i++)
	{
		if (i == 0)
			printf("������\t");
		else if (i == 1)
			printf("���߱�\t");
		else if (i == 2)
			printf("������\t");
		else if (i == 3)
			printf("�嵿��\t");
		else if (i == 4)
			printf(" �հ�\t");
		else
			printf(" ���\t");

		for (j = 0; j < 7; j++)
		{
			printf("%3d\t", arr1[i][j]);
		}
		printf("%c", arr1[i][7]);
		printf("\n");
	}
	printf("\n\n");
}
//1�б� ���� �հ� & ���, ��� ���ϱ�

void Array2(void)
{
	printf("2�б� ������ �־��ּ���.\n");
	//�л��� ���� �հ�, ���
	for (i = 0; i < 4; i++)
	{
		sum3 = 0;
		for (j = 0; j < 5; j++)
		{
			scanf_s("%d", &arr2[i][j]);
			sum3 += arr2[i][j];
		}
		arr2[i][5] = sum3;
		avr3 = sum3 / 5;
		arr2[i][6] = avr3;

		if (avr3 >= 90)
			grade = 'A';
		else if (avr3 >= 80 && avr3 < 90)
			grade = 'B';
		else if (avr3 >= 70 && avr3 < 80)
			grade = 'C';
		else if (avr3 >= 60 && avr3 < 70)
			grade = 'D';
		else
			grade = 'F';

		arr2[i][7] = grade;
	}

	//���� ���� �Է�, �հ�, ���
	for (i = 0; i < 5; i++)
	{
		sum4 = 0;
		for (j = 0; j < 4; j++)
		{
			sum4 += arr2[j][i];
		}
		arr2[4][i] = sum4;
		avr4 = sum4 / 4;
		arr2[5][i] = avr4;
	}

	//ShowAll
	printf("\n\n<<2�б� ����>>\n");
	printf("\n�̸�\t" "����\t" "����\t" "����\t" "��ȸ\t" "����\t" "�հ�\t" "���\t""���\n\n");
	for (i = 0; i < 6; i++)
	{
		if (i == 0)
			printf("������\t");
		else if (i == 1)
			printf("���߱�\t");
		else if (i == 2)
			printf("������\t");
		else if (i == 3)
			printf("�嵿��\t");
		else if (i == 4)
			printf(" �հ�\t");
		else
			printf(" ���\t");

		for (j = 0; j < 7; j++)
		{
			printf("%3d\t", arr2[i][j]);
		}
		printf("%c", arr2[i][7]);
		printf("\n");
	}
	printf("\n\n");
}
//2�б� ���� �Է�, �հ� & ���, ��� ���ϱ�

void CompareArrays(void)
{
	printf("<<1�б�� 2�б� ���� ��>> \n\n");
	printf("\t����  \t����  \t����  \t��ȸ  \t����  \t����  \t���\n\n");

	int result[6][8];

	for (i = 0; i < 6; i++)
	{
		for (int j = 0; j < 7; j++)
		{
			result[i][j] = arr2[i][j]-arr1[i][j];
		}
	}

	for (i = 0; i < 6; i++)
	{
		if (i == 0)
			printf("������\t");
		else if (i == 1)
			printf("���߱�\t");
		else if (i == 2)
			printf("������\t");
		else if (i == 3)
			printf("�嵿��\t");
		else if (i == 4)
			printf(" �հ�\t");
		else
			printf(" ���\t");

		for (j = 0; j < 7; j++)
		{
			printf("%d", result[i][j]);
			if (result[i][j] < 0)
			{
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED | FOREGROUND_INTENSITY);
				printf("(��)\t");
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
			}
			else if (result[i][j] == 0)
				printf("(==)\t");
			else
			{
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_GREEN | FOREGROUND_INTENSITY);
				printf("(��)\t");
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
			}
		}
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
		printf("\n");
	}

	printf("\n\n");
	for (int i = 0; i < 4; i++)
	{
		if (i == 0)
			printf("��1�б� ��� ������ ������\n\n");
		else if (i == 1)
			printf("��1�б� ��� ���߱� ������\n\n");
		else if (i == 2)
			printf("��1�б� ��� ������ ������\n\n");
		else if (i == 3)
			printf("��1�б� ��� �嵿�� ������\n\n");

		for (int j = 0; j < 7; j++)
		{
			if (j == 0)
				printf("����� ");
			else if (j == 1)
				printf("����� ");
			else if (j == 2)
				printf("���м��� ");
			else if (j == 3)
				printf("��ȸ���� ");
			else if (j == 4)
				printf("���м��� ");
			else if (j == 5)
				printf("���� ");
			else
				printf("��� ");

			result[i][j] = arr2[i][j] - arr1[i][j];
			if (result[i][j] < 0)
				printf("1�б� ��� %d�� ���������ϴ�.\n", result[i][j]);
				else if (result[i][j] == 0)
				printf("1�б�� �����մϴ�.\n");
			else
				printf("1�б� ��� %d�� �ö����ϴ�.\n", result[i][j]);
		}

		if (result[i][6] > 0)
		{
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
			puts("***�����մϴ�. ������ ���Ǿ����ϴ�.***\n\n");
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
		}
		else if (result[i][6] == 0)
			printf("***������ ��ȭ�� ���׿�.***\n\n");
			
		else
		{
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
			printf("***������ ���������ϴ�. ������ �ϼ���.***\n\n");
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
		}
	}						
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	printf("\n");
}
//1�б� 2�б� �� �� COMMENTS

main()
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_INTENSITY);
	puts("KB Students' Score Management System\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	Array1();
	Array2();
	CompareArrays();

	return 0;
}