using System;
using Certificados.Models;
using Certificados.Services;

namespace Certificados
{
    public class Program
    {
        public struct CertificationInfos
        {
            public string Title;
            public string Description;
            public string IssuingEntity;
            public int DurationInHours;
            public string IssuedAt;
        };

        private static CertificationService _service = new CertificationService();

        static void Main()
        {
            _service.Add(new Certification
            {
                Title = "Bootcamp LocalizaLabs .NET Developer #2",
                Description =
@"O Bootcamp LocalizaLabs .NET Developer #2, faz parte do programa
Órbi Academy Techboost - com uma iniciativa da DIO junto ao Órbi, está pronto para você!
Neste Bootcamp você aprenderá os conceitos principais sobre .NET para atuação em projetos
de desenvolvimento web e de componentes de interface de usuários.
O Órbi Conecta é um dos principais hubs de inovação do Brasil e o Órbi Academy Techboost
é um dos maiores programas brasileiros de formação em carreiras de tecnologia que distribuirá mais de
130 mil bolsas de estudo até 2022, impactando toda a comunidade tech brasileira.",
                IssuingEntity = "Digital Innovation One - DIO",
                DurationInHours = 74,
                IssuedAt = "12 de fevereiro de 2022"
            });

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada:\n");
                Console.WriteLine("1) Exibir certificados");
                Console.WriteLine("2) Adicionar um certificado");
                Console.WriteLine("3) Atualizar um certificado");
                Console.WriteLine("4) Excluir um certificado");
                Console.WriteLine("5) Visualizar um certificado\n");
                Console.WriteLine();
                Console.WriteLine("0) Sair");
                Console.WriteLine();

                int input = Convert.ToInt32(Console.ReadLine());
                if (input <= 0)
                    break;

                Console.Clear();

                switch (input)
                {
                    case 1:
                        GetAllCertifications();
                        break;
                    case 2:
                        AddCertification();
                        break;
                    case 3:
                        UpdateCertification();
                        break;
                    case 4:
                        DeleteCertification();
                        break;
                    case 5:
                        GetCertificationById();
                        break;
                    default:
                        Console.WriteLine("Input inválido!");
                        break;
                }

                Console.WriteLine("Pressione ENTER para voltar para o menu.");
                Console.ReadLine();
            }
        }

        private static CertificationInfos GetCertificationInfos()
        {
            var cert = new CertificationInfos();
            Console.WriteLine("Nome do certificado/bootcamp:");
            cert.Title = Console.ReadLine();

            Console.WriteLine("Descrição das atividades:");
            cert.Description = Console.ReadLine();

            Console.WriteLine("Entidade emissora (ex.: DIO):");
            cert.IssuingEntity = Console.ReadLine();

            Console.WriteLine("Duração em horas (ex.: 13):");
            cert.DurationInHours = int.Parse(Console.ReadLine());

            Console.WriteLine("Data de emissão (ex.: 22 de Janeiro de 2022):");
            cert.IssuedAt = Console.ReadLine();

            return cert;
        }

        private static void GetAllCertifications()
        {
            var certifications = _service.GetAll();
            if (certifications.Count <= 0)
            {
                Console.WriteLine("Nenhum certificado cadastrado até o momento!");
                return;
            }

            foreach (var item in certifications)
                Console.WriteLine(item.ToString() + "\n");
        }

        private static void AddCertification()
        {
            var infos = GetCertificationInfos();

            var certification = new Certification
            {
                Title = infos.Title,
                Description = infos.Description,
                IssuingEntity = infos.IssuingEntity,
                DurationInHours = infos.DurationInHours,
                IssuedAt = infos.IssuedAt
            };

            int n = _service.Add(certification) + 1;
            Console.WriteLine($"Parabéns!\nSeu {n}º certificado foi adicionado!");
        }

        private static void UpdateCertification()
        {
            Console.WriteLine("Digite o Id do certificado que deseja alterar:");
            int id = int.Parse(Console.ReadLine());

            var infos = GetCertificationInfos();

            var certification = new Certification
            {
                Title = infos.Title,
                Description = infos.Description,
                IssuingEntity = infos.IssuingEntity,
                DurationInHours = infos.DurationInHours,
                IssuedAt = infos.IssuedAt
            };

            var updated = _service.Update(id, certification);
            if (!updated)
                Console.WriteLine("Certificado não encontrado!");
            else
                Console.WriteLine("Certificado atualizado!");
        }

        private static void DeleteCertification()
        {
            Console.WriteLine("Digite o Id do certificado que deseja deletar:");
            int id = int.Parse(Console.ReadLine());

            var deleted = _service.Delete(id);

            if (!deleted)
                Console.WriteLine("Certificado não encontrado!");
            else
                Console.WriteLine("Certificado deletado!");
        }

        private static void GetCertificationById()
        {
            Console.WriteLine("Digite o Id do certificado que deseja exibir:");
            int id = int.Parse(Console.ReadLine());

            var certification = _service.GetById(id);
            if (certification == null)
                Console.WriteLine("Certificado não encontrado!");
            else
                Console.WriteLine(certification.ToString());
        }
    }
}