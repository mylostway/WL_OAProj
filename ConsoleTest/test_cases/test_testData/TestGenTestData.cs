using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Bogus;
using WL_OA.Data;

namespace ConsoleTest.test_cases
{
    public class TestGenTestData
    {
        class Person
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public DateTime BirthDay { get; set; }

            public override string ToString()
            {
                return JsonHelper.SerializeTo(this);
            }
        }

        const string DEFAULT_FAKER_LOCALE = "zh_CN";

        const int DEFAULT_GEN_INSTANCE_COUNT = 20;

        public void TestCase_WithPropertyRules()
        {
            var faker1 = new Faker<Person>(DEFAULT_FAKER_LOCALE).StrictMode(true)
                .RuleFor(x => x.ID, f => f.IndexGlobal)
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Address, f => f.Address.Locale)
                .RuleFor(x => x.Phone, f => f.Person.Phone)
                .RuleFor(x => x.BirthDay, f => f.Person.DateOfBirth);

            var genDatas = faker1.Generate(DEFAULT_GEN_INSTANCE_COUNT);

            Console.WriteLine("-------------- test gen data with property rules:");
            foreach (var e in genDatas)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("-------------- end");
            Console.WriteLine();
        }


        Dictionary<string, PropertyInfo> m_dicFakerPropertiesNames = new Dictionary<string, PropertyInfo>();

        Faker m_faker = new Faker(DEFAULT_FAKER_LOCALE);

        public void InitFaker()
        {
            var fakerType = typeof(Faker);

            var fakerProperties = fakerType.GetProperties(BindingFlags.Public|BindingFlags.Instance);

            foreach (var e in fakerProperties)
            {
                m_dicFakerPropertiesNames.Add(e.Name.ToLower(), e);
            }
        }


        /// <summary>
        /// 使用反射匹配Faker生成随机字段值，目前不能使用
        /// </summary>
        public void TestCase_WithIndependentFaker()
        {
            InitFaker();

            var genPersonList = new List<Person>();

            var genType = typeof(Person);

            var properties = genType.GetProperties();

            for(var i = 0;i < DEFAULT_GEN_INSTANCE_COUNT;i++)
            {
                var obj = Activator.CreateInstance(genType);

                foreach (var e in properties)
                {
                    var isSet = false;
                    foreach (var eFakeProperty in m_dicFakerPropertiesNames)
                    {
                        var fakePropertyInfo = eFakeProperty.Value;
                        if (e.Name.ToLower().IndexOf(eFakeProperty.Key) >= 0 && fakePropertyInfo.PropertyType == e.PropertyType)
                        {
                            isSet = true;
                            e.SetValue(obj, eFakeProperty.Value.GetGetMethod().Invoke(m_faker, new object[] { }));
                            break;
                        }
                        else
                        {

                        }
                    }
                    if(!isSet)
                    {
                        // 没有使用Faker生成随机值                        
                    }
                }

                genPersonList.Add(obj as Person);
            }

            Console.WriteLine("-------------- test gen data with property rules:");
            foreach (var e in genPersonList)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("-------------- end");
            Console.WriteLine();
        }

        public void Run()
        {
            //TestCase_WithPropertyRules();

            TestCase_WithIndependentFaker();
        }

    }
}
