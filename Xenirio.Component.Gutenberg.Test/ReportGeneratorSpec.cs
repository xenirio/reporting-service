﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xenirio.Component.Gutenberg.Model;

namespace Xenirio.Component.Gutenberg.Tests
{
    [TestClass]
    public class ReportGeneratorSpec
    {
        private string[] remarks = new string[] {
        @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer rutrum, nisi sit amet maximus placerat, purus lorem maximus orci, pulvinar placerat erat velit sit amet lectus. Quisque sed sapien eget lectus posuere interdum at congue arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam quis lectus sapien. Etiam tristique sed eros quis luctus. Quisque cursus, magna id porta accumsan, augue massa ornare sem, ac ullamcorper tortor nisi nec erat. Proin massa lacus, tincidunt sed massa ac, dapibus gravida lorem. Aliquam et tincidunt ipsum. Sed eleifend varius varius. Nunc elementum molestie purus, at pharetra turpis pharetra id. Suspendisse semper, sem ut vehicula pulvinar, ante dolor efficitur quam, ut mollis neque lectus et mauris. Pellentesque eu est ac justo varius ultrices in vitae enim. Cras nec orci sed lectus lobortis convallis.",
        @"Quisque eleifend condimentum urna, sed viverra lorem mollis eu. Aenean pellentesque venenatis lorem placerat mollis. Nam blandit, metus sodales dictum commodo, purus libero luctus metus, eget consectetur velit lacus dapibus lacus. Morbi dictum lectus a risus ultricies, in sodales dolor posuere. Sed cursus, lectus eget tempor dignissim, nisl risus vehicula libero, in iaculis tortor nisl ornare enim. Ut fermentum nunc at ipsum scelerisque semper. Ut bibendum ut libero ut facilisis.",
			//@"Quisque congue pharetra est et ornare. Vestibulum in mauris at elit iaculis sagittis vitae quis urna. Aliquam blandit dictum metus vel consectetur. Curabitur vestibulum elit sed nulla euismod fringilla. Duis eu vestibulum felis. Sed consequat fringilla mauris, at vehicula nunc auctor nec. Duis sed magna vehicula, dictum ex vel, facilisis arcu. Aenean tortor nulla, tempus in libero quis, rutrum molestie orci. Nam nec ipsum semper, vestibulum ligula eget, ornare sapien. Phasellus fringilla sodales tempus. Ut finibus velit rhoncus tortor egestas, et vulputate ipsum hendrerit. Suspendisse volutpat rutrum lectus eget lacinia. Vivamus tincidunt semper velit. Morbi eget ante quis odio venenatis mattis. Vivamus sit amet ipsum ac magna imperdiet eleifend ac a augue. Sed quis nunc in nulla eleifend pretium vel faucibus dolor.",
			//@"Nam congue nisi ut felis dictum egestas. Praesent volutpat est quis ultrices tempus. Vestibulum laoreet tempor blandit. Sed congue libero nulla, at facilisis magna fermentum eu. Phasellus facilisis cursus augue ut efficitur. Cras non purus diam. Praesent sem risus, vulputate sit amet finibus vel, bibendum a sem. Nulla tincidunt dignissim justo, at venenatis arcu. Proin consectetur augue et ante iaculis fermentum. Mauris eu sollicitudin nulla, nec ultricies nibh. Ut accumsan scelerisque ultrices.",
			//@"Ut dapibus nisl et malesuada aliquet. Etiam vehicula felis vitae pulvinar finibus. Vestibulum sed convallis ipsum, sit amet euismod arcu. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus erat eros, feugiat ultricies lorem sit amet, tempor aliquam magna. Duis hendrerit diam a ornare scelerisque. Etiam volutpat, turpis non laoreet consectetur, leo lacus rhoncus lorem, vel tempus augue augue non erat. Praesent id urna leo. Ut et faucibus ipsum, ut hendrerit erat. Curabitur feugiat risus facilisis elit hendrerit, et consequat lectus luctus. Duis velit nulla, aliquam id felis non, aliquet commodo leo. Ut vitae hendrerit sapien."
		};
        private string[] chineseRemarks = new string[] {
        @"協州区乏指権庭手額更見並普況。供交査意山闘中壊辞良島健型秋。級度協条末能長載更政何誇売利店案昔模下。突意面元温立増許明断勝指促複際県。活京事集派実熱性地場泉載胸使宮言掲。卒真爆真果込止次泉京開決豊食署趣表遅。年族取画園豊資太小仕袋面表前権頂格。修第索公社明件止県果崩原内友撤老県優立。大郎団提容月断害族寄火記谷談館水。",
        @"除線図臨析禁摘布府白読事。最目智教掲訃朱高暮協近間企込祖遣健権変頭。無翌手待受続本祐廟日刊分提月。占抜頑郎業役刊意金認事修。継士贈接挙奏無導思阪尉導配法久融名社第断。著省障球秋空備授変済真訃康型便去了供写現。載懲常購必置想的建約人過民。著清戸談案毎周作難部一問禁詳杉将変礁金。作復贈同再足警密開責異査飾号裏恵更基。",
		//@"金住応気育止去登報抗武立暮支備。能人覧則君資美勧海投禁筋新策紙。訴広最講木同負胃題働最古都。寺木友占析悪色時果不百規事高学利西健府耗。作状権写解達関学立治読球午条。掲子惑必諭会書読備他際速。検宮年性手稲耐粘火景米国界。位図病見液選虐医百福通今注備更。面家構企晴地送掲栖犯店要震政団。声帳窃来接採首学塾備挙破証光無交学質。",
		//@"阪目知添相歴第聞委人所都動。覧写枝性満予前原時相行県木。統発無等少野月給図載名題求結章用近。政要投覧属譲退和竹見婦作。速機屋国友倒年県海富有購検載公。同前黒航場本際会同聞講偽橋事話健込都。一夕健峠展請意世未見輔人府摘軟営表林大。転避利法理元研根稿即油県。天挑拠公勤信遣番読付薄気活切委。使角注木続案主教案転子産列付源報。",
		//@"率載脳展地文集世惑入家携北中断覧映芸氏。意締分探幸度申摯特挨楽止。監作再国玄会豊者連年惑価常訴却取指経在。増思均穂重週端包枝開意種年。江愛供検向日政造全川備徹後府石米田倍。問駆万日区人爆開刊初回入治名一面。月勝園構航帳図高発転球立新台影以級計康応。室睦億打投研時更投快花国煙変。県画達身女点天投乳平禁川載手科映志税欺。"
		};

        [TestMethod]
        public void Should_Generate_Bytes_Report()
        {
            var template = Environment.CurrentDirectory + @"\Resources\Sample.docx";
            var report = new ReportGenerator(template);
            report.setParagraph("Header.Entity.Name", "IPO of Ezra Holdings Limited");
            report.setParagraph("Footer.Creator", "Vee");
            report.setParagraph("Content.Entity.Name", "IPO of Ezra Holdings");
            report.setParagraphs("Content.Entity.Names", new string[] { "IPO of Ezra Holdings Limited", "IPO of Ezra" });
            report.setParagraphs("Content.Entity.Remark", remarks);
            report.setParagraphs("Content.Entity.Remark.Chinese", chineseRemarks);
            Assert.IsNotNull(report.GenerateToByte());
        }

        [TestMethod]
        public void Should_Generate_File_Report()
        {
            var template = Environment.CurrentDirectory + @"\Resources\Sample.docx";
            var report = new ReportGenerator(template);
            //report.setParagraph("Header.Entity.Name", "IPO of Ezra Holdings Limited");
            report.setParagraph("Footer.DateTime", DateTime.Now.ToShortDateString());
            report.setParagraph("Footer.Creator", "Vee");
            report.setParagraph("Content.Entity.Name", "IPO of Ezra Holdings Limited");
            report.setParagraphs("Content.Entity.Names", new string[] { "IPO of Ezra Holdings Limited", "IPO of Ezra" });
            report.setParagraph("Content.Entity.Type", "EVENT");
            report.setParagraph("Content.Entity.SubType", "IPO");
            report.setParagraphs("Content.Entity.Remark", remarks.Concat(chineseRemarks).ToArray());
            report.setParagraph("Content.Entity.Place", "Singapore");
            report.setParagraph("Content.Entity.Number", "ISG8754");
            report.setParagraph("Content.Entity.Date", "3 July 1988");
            report.setTableParagraph("Content.Entity.Connections", new string[][] {
                new string[] { "Total Entities", "7" },
                new string[] { "Person", "0" },
                new string[] { "Corporate", "7" },
                new string[] { "Events", "0" },
                new string[] { "Others", "0" }
            });

            var outputPath = string.Format(@"{0}\{1}{2}.docx", Path.GetDirectoryName(template), Path.GetFileNameWithoutExtension(template), DateTime.Now.Ticks);
            report.GenerateToFile(outputPath);
            Assert.IsTrue(File.Exists(outputPath));
        }

        [TestMethod]
        public void Should_Generate_Images_Report()
        {
            var template = Environment.CurrentDirectory + @"\Resources\SampleImageTable.docx";
            var report = new ReportGenerator(template);
            var byteLogo = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\logo.png");

            var byteLogos = new byte[][][] {
                new byte[][] { byteLogo },
                new byte[][] { byteLogo },
                new byte[][] { byteLogo }
            };
            report.setTableImage("Content.Image.Logo", byteLogos);

            var outputPath = string.Format(@"{0}\{1}{2}.docx", Path.GetDirectoryName(template), Path.GetFileNameWithoutExtension(template), DateTime.Now.Ticks);
            report.GenerateToFile(outputPath);
            Assert.IsTrue(File.Exists(outputPath));
        }

        [TestMethod]
        public void Should_Generate_Complex_Table_Report()
        {
            var template = Environment.CurrentDirectory + @"\Resources\SampleTableAdvance.docx";
            var report = new ReportGenerator(template);
            var byteBanner = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\banner.png");
            report.InjectReportElement(new ReportTableComplex()
            {
                Key = "Content.Table.Rule",
                Elements = new ReportElement[][] {
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Title", Value = "Rule 1" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Entity.Name", Value = "ABC" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Line.Top", Value = "" }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Line.Bottom", Value = "" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Entity.Name", Value = "DEF" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Line.Top", Value = "" }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Line.Bottom", Value = "" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Title", Value = "Rule 2" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Entity.Name", Value = "GHI" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Line.Top", Value = "" }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Line.Bottom", Value = "" }
                    },
                }
            });
            var outputPath = string.Format(@"{0}\{1}{2}.docx", Path.GetDirectoryName(template), Path.GetFileNameWithoutExtension(template), DateTime.Now.Ticks);
            report.GenerateToFile(outputPath);
            Assert.IsTrue(File.Exists(outputPath));
        }

        [TestMethod]
        public void Should_Replace_Report_Template()
        {
            var template = Environment.CurrentDirectory + @"\Resources\SampleContentTemplate.docx";
            var report = new ReportGenerator(template);
            var data = new string[][]{
                new string[] { "Fire Bolt", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ante tellus, porttitor sit amet pretium ut, luctus sed lorem. Praesent viverra accumsan porta. Mauris ante magna, condimentum in vestibulum efficitur, maximus at justo. Nulla eget nisi in dolor mollis tempus vitae sit amet lorem", "16" },
                new string[] { "Thunder Storm", "Pellentesque felis magna, congue et dolor quis, sagittis tristique nulla. Etiam tincidunt eleifend justo, at rhoncus nisi efficitur ac. Cras ipsum tellus, ultrices vitae nulla vel, posuere rhoncus leo. Aliquam volutpat erat nulla. Nam non elementum augue, sit amet tempor lorem", "12" },
                new string[] { "Cold Snap", "Curabitur vel turpis imperdiet, dignissim nulla at, dignissim orci. Fusce rutrum congue mauris, eget pulvinar est laoreet id. Vestibulum lobortis, mauris et varius condimentum, lectus risus bibendum dui, eget sodales lectus justo nec nibh. Sed ullamcorper magna et neque suscipit efficitur", "24" }
            }.Select(r =>
            {
                var result = new List<IReportReplaceable>();
                result.Add(new ReportLabel() { Key = "Skill.Name", Value = r[0] });
                result.Add(new ReportLabel() { Key = "Skill.Effect", Value = r[1] });
                result.Add(new ReportLabel() { Key = "Skill.Cost", Value = r[2] });

                return result.ToArray();
            }).ToArray();

            report.InjectReportElement(new ReportTemplateElement()
            {
                Key = "Content.Skills",
                TemplateKey = "Skill",
                Value = data
            });
            report.registerTemplate("Skill");

            var outputPath = string.Format(@"{0}\{1}{2}.docx", Path.GetDirectoryName(template), Path.GetFileNameWithoutExtension(template), DateTime.Now.Ticks);
            report.GenerateToFile(outputPath);
            Assert.IsTrue(File.Exists(outputPath));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Should_Throw_With_Missing_Field_Information()
        {
            var template = Environment.CurrentDirectory + @"\Resources\SampleContentTemplate.docx";
            var report = new ReportGenerator(template);
            report.setParagraph("Blah", "");
            var outputPath = string.Format(@"{0}\{1}{2}.docx", Path.GetDirectoryName(template), Path.GetFileNameWithoutExtension(template), DateTime.Now.Ticks);
            report.GenerateToFile(outputPath);
            Assert.IsFalse(File.Exists(outputPath));
        }
    }
}
