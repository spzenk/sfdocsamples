using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Performance_Timer_Tasks
{
    public delegate void IncidentHandler(int procId,long time);
    public partial class Engine : Component
    {

        Dictionary<int, Processor> _ProcessorDictionary = new Dictionary<int, Processor>();
        public List<Statistics> Statistics = new List<Statistics>();
        public int PocessCount { get; set; }
        public int RefreshTime { get; set; }
        public Engine()
        {
            InitializeComponent(); 
                
        }

        public Engine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Init();
        }


        public void Start()
        {
            Processor wIProcessor = null;
            try
            {

                for (int i = 0; i <= PocessCount; i++)
                {
                    wIProcessor = new Processor();
                    wIProcessor.ProcessorId = i;
                    wIProcessor.RefreshTime = this.RefreshTime;
                    _ProcessorDictionary.Add(wIProcessor.ProcessorId, wIProcessor);
                    wIProcessor.IncidentEvent += new IncidentHandler(wIProcessor_IncidentEvent);
                    wIProcessor.Start();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        void wIProcessor_IncidentEvent(int procId,long time)
        {
            Statistics st = new Statistics();
            st.ProcessorId = procId;
            st.Time = time;
            
            Statistics.Add(st);

            //_ProcessorDictionary[procId].Stop();
            //_ProcessorDictionary.Remove(procId);
        }

        public void Stop()
        {
            foreach (int pid in _ProcessorDictionary.Keys)
            {
                _ProcessorDictionary[pid].Stop();
            }
           
           
        }




        internal void Clear()
        {
            _ProcessorDictionary.Clear();
            Statistics.Clear();
        }

        internal static Dictionary<int, int> ProductIdList;
        void Init()
        {
            ProductIdList = new Dictionary<int, int>();
            ProductIdList.Add(0, 1);
            ProductIdList.Add(1, 2);
            ProductIdList.Add(2, 3);
            ProductIdList.Add(3, 4);
            ProductIdList.Add(4, 316);
            ProductIdList.Add(5, 317);
            ProductIdList.Add(6, 318);
            ProductIdList.Add(7, 319);
            ProductIdList.Add(8, 320);
            ProductIdList.Add(9, 321);
            ProductIdList.Add(10, 322);
            ProductIdList.Add(11, 323);
            ProductIdList.Add(12, 324);
            ProductIdList.Add(13, 325);
            ProductIdList.Add(14, 326);
            ProductIdList.Add(15, 327);
            ProductIdList.Add(16, 328);
            ProductIdList.Add(17, 329);
            ProductIdList.Add(18, 330);
            ProductIdList.Add(19, 331);
            ProductIdList.Add(20, 332);
            ProductIdList.Add(21, 341);
            ProductIdList.Add(22, 342);
            ProductIdList.Add(23, 343);
            ProductIdList.Add(24, 344);
            ProductIdList.Add(25, 345);
            ProductIdList.Add(26, 346);
            ProductIdList.Add(27, 347);
            ProductIdList.Add(28, 348);
            ProductIdList.Add(29, 349);
            ProductIdList.Add(30, 350);
            ProductIdList.Add(31, 351);
            ProductIdList.Add(32, 352);
            ProductIdList.Add(33, 355);
            ProductIdList.Add(34, 356);
            ProductIdList.Add(35, 357);
            ProductIdList.Add(36, 358);
            ProductIdList.Add(37, 359);
            ProductIdList.Add(38, 360);
            ProductIdList.Add(39, 361);
            ProductIdList.Add(40, 362);
            ProductIdList.Add(41, 363);
            ProductIdList.Add(42, 364);
            ProductIdList.Add(43, 365);
            ProductIdList.Add(44, 366);
            ProductIdList.Add(45, 367);
            ProductIdList.Add(46, 368);
            ProductIdList.Add(47, 369);
            ProductIdList.Add(48, 370);
            ProductIdList.Add(49, 371);
            ProductIdList.Add(50, 372);
            ProductIdList.Add(51, 373);
            ProductIdList.Add(52, 374);
            ProductIdList.Add(53, 375);
            ProductIdList.Add(54, 376);
            ProductIdList.Add(55, 377);
            ProductIdList.Add(56, 378);
            ProductIdList.Add(57, 379);
            ProductIdList.Add(58, 380);
            ProductIdList.Add(59, 381);
            ProductIdList.Add(60, 382);
            ProductIdList.Add(61, 383);
            ProductIdList.Add(62, 384);
            ProductIdList.Add(63, 385);
            ProductIdList.Add(64, 386);
            ProductIdList.Add(65, 387);
            ProductIdList.Add(66, 388);
            ProductIdList.Add(67, 389);
            ProductIdList.Add(68, 390);
            ProductIdList.Add(69, 391);
            ProductIdList.Add(70, 392);
            ProductIdList.Add(71, 393);
            ProductIdList.Add(72, 394);
            ProductIdList.Add(73, 395);
            ProductIdList.Add(74, 396);
            ProductIdList.Add(75, 397);
            ProductIdList.Add(76, 398);
            ProductIdList.Add(77, 399);
            ProductIdList.Add(78, 400);
            ProductIdList.Add(79, 401);
            ProductIdList.Add(80, 402);
            ProductIdList.Add(81, 403);
            ProductIdList.Add(82, 404);
            ProductIdList.Add(83, 405);
            ProductIdList.Add(84, 406);
            ProductIdList.Add(85, 407);
            ProductIdList.Add(86, 408);
            ProductIdList.Add(87, 409);
            ProductIdList.Add(88, 410);
            ProductIdList.Add(89, 411);
            ProductIdList.Add(90, 412);
            ProductIdList.Add(91, 413);
            ProductIdList.Add(92, 414);
            ProductIdList.Add(93, 415);
            ProductIdList.Add(94, 416);
            ProductIdList.Add(95, 417);
            ProductIdList.Add(96, 418);
            ProductIdList.Add(97, 419);
            ProductIdList.Add(98, 420);
            ProductIdList.Add(99, 421);
            ProductIdList.Add(100, 422);
            ProductIdList.Add(101, 423);
            ProductIdList.Add(102, 424);
            ProductIdList.Add(103, 425);
            ProductIdList.Add(104, 426);
            ProductIdList.Add(105, 427);
            ProductIdList.Add(106, 428);
            ProductIdList.Add(107, 429);
            ProductIdList.Add(108, 430);
            ProductIdList.Add(109, 431);
            ProductIdList.Add(110, 432);
            ProductIdList.Add(111, 433);
            ProductIdList.Add(112, 434);
            ProductIdList.Add(113, 435);
            ProductIdList.Add(114, 436);
            ProductIdList.Add(115, 437);
            ProductIdList.Add(116, 438);
            ProductIdList.Add(117, 439);
            ProductIdList.Add(118, 440);
            ProductIdList.Add(119, 441);
            ProductIdList.Add(120, 442);
            ProductIdList.Add(121, 443);
            ProductIdList.Add(122, 444);
            ProductIdList.Add(123, 445);
            ProductIdList.Add(124, 446);
            ProductIdList.Add(125, 447);
            ProductIdList.Add(126, 448);
            ProductIdList.Add(127, 449);
            ProductIdList.Add(128, 450);
            ProductIdList.Add(129, 451);
            ProductIdList.Add(130, 452);
            ProductIdList.Add(131, 453);
            ProductIdList.Add(132, 454);
            ProductIdList.Add(133, 455);
            ProductIdList.Add(134, 456);
            ProductIdList.Add(135, 457);
            ProductIdList.Add(136, 458);
            ProductIdList.Add(137, 459);
            ProductIdList.Add(138, 460);
            ProductIdList.Add(139, 461);
            ProductIdList.Add(140, 462);
            ProductIdList.Add(141, 463);
            ProductIdList.Add(142, 464);
            ProductIdList.Add(143, 465);
            ProductIdList.Add(144, 466);
            ProductIdList.Add(145, 467);
            ProductIdList.Add(146, 468);
            ProductIdList.Add(147, 469);
            ProductIdList.Add(148, 470);
            ProductIdList.Add(149, 471);
            ProductIdList.Add(150, 472);
            ProductIdList.Add(151, 473);
            ProductIdList.Add(152, 474);
            ProductIdList.Add(153, 475);
            ProductIdList.Add(154, 476);
            ProductIdList.Add(155, 477);
            ProductIdList.Add(156, 478);
            ProductIdList.Add(157, 479);
            ProductIdList.Add(158, 480);
            ProductIdList.Add(159, 481);
            ProductIdList.Add(160, 482);
            ProductIdList.Add(161, 483);
            ProductIdList.Add(162, 484);
            ProductIdList.Add(163, 485);
            ProductIdList.Add(164, 486);
            ProductIdList.Add(165, 487);
            ProductIdList.Add(166, 488);
            ProductIdList.Add(167, 489);
            ProductIdList.Add(168, 490);
            ProductIdList.Add(169, 491);
            ProductIdList.Add(170, 492);
            ProductIdList.Add(171, 493);
            ProductIdList.Add(172, 494);
            ProductIdList.Add(173, 495);
            ProductIdList.Add(174, 496);
            ProductIdList.Add(175, 497);
            ProductIdList.Add(176, 504);
            ProductIdList.Add(177, 505);
            ProductIdList.Add(178, 506);
            ProductIdList.Add(179, 507);
            ProductIdList.Add(180, 508);
            ProductIdList.Add(181, 509);
            ProductIdList.Add(182, 510);
            ProductIdList.Add(183, 511);
            ProductIdList.Add(184, 512);
            ProductIdList.Add(185, 513);
            ProductIdList.Add(186, 514);
            ProductIdList.Add(187, 515);
            ProductIdList.Add(188, 516);
            ProductIdList.Add(189, 517);
            ProductIdList.Add(190, 518);
            ProductIdList.Add(191, 519);
            ProductIdList.Add(192, 520);
            ProductIdList.Add(193, 521);
            ProductIdList.Add(194, 522);
            ProductIdList.Add(195, 523);
            ProductIdList.Add(196, 524);
            ProductIdList.Add(197, 525);
            ProductIdList.Add(198, 526);
            ProductIdList.Add(199, 527);
            ProductIdList.Add(200, 528);
            ProductIdList.Add(201, 529);
            ProductIdList.Add(202, 530);
            ProductIdList.Add(203, 531);
            ProductIdList.Add(204, 532);
            ProductIdList.Add(205, 533);
            ProductIdList.Add(206, 534);
            ProductIdList.Add(207, 535);
            ProductIdList.Add(208, 679);
            ProductIdList.Add(209, 680);
            ProductIdList.Add(210, 706);
            ProductIdList.Add(211, 707);
            ProductIdList.Add(212, 708);
            ProductIdList.Add(213, 709);
            ProductIdList.Add(214, 710);
            ProductIdList.Add(215, 711);
            ProductIdList.Add(216, 712);
            ProductIdList.Add(217, 713);
            ProductIdList.Add(218, 714);
            ProductIdList.Add(219, 715);
            ProductIdList.Add(220, 716);
            ProductIdList.Add(221, 717);
            ProductIdList.Add(222, 718);
            ProductIdList.Add(223, 719);
            ProductIdList.Add(224, 720);
            ProductIdList.Add(225, 721);
            ProductIdList.Add(226, 722);
            ProductIdList.Add(227, 723);
            ProductIdList.Add(228, 724);
            ProductIdList.Add(229, 725);
            ProductIdList.Add(230, 726);
            ProductIdList.Add(231, 727);
            ProductIdList.Add(232, 728);
            ProductIdList.Add(233, 729);
            ProductIdList.Add(234, 730);
            ProductIdList.Add(235, 731);
            ProductIdList.Add(236, 732);
            ProductIdList.Add(237, 733);
            ProductIdList.Add(238, 734);
            ProductIdList.Add(239, 735);
            ProductIdList.Add(240, 736);
            ProductIdList.Add(241, 737);
            ProductIdList.Add(242, 738);
            ProductIdList.Add(243, 739);
            ProductIdList.Add(244, 740);
            ProductIdList.Add(245, 741);
            ProductIdList.Add(246, 742);
            ProductIdList.Add(247, 743);
            ProductIdList.Add(248, 744);
            ProductIdList.Add(249, 745);
            ProductIdList.Add(250, 746);
            ProductIdList.Add(251, 747);
            ProductIdList.Add(252, 748);
            ProductIdList.Add(253, 749);
            ProductIdList.Add(254, 750);
            ProductIdList.Add(255, 751);
            ProductIdList.Add(256, 752);
            ProductIdList.Add(257, 753);
            ProductIdList.Add(258, 754);
            ProductIdList.Add(259, 755);
            ProductIdList.Add(260, 756);
            ProductIdList.Add(261, 757);
            ProductIdList.Add(262, 758);
            ProductIdList.Add(263, 759);
            ProductIdList.Add(264, 760);
            ProductIdList.Add(265, 761);
            ProductIdList.Add(266, 762);
            ProductIdList.Add(267, 763);
            ProductIdList.Add(268, 764);
            ProductIdList.Add(269, 765);
            ProductIdList.Add(270, 766);
            ProductIdList.Add(271, 767);
            ProductIdList.Add(272, 768);
            ProductIdList.Add(273, 769);
            ProductIdList.Add(274, 770);
            ProductIdList.Add(275, 771);
            ProductIdList.Add(276, 772);
            ProductIdList.Add(277, 773);
            ProductIdList.Add(278, 774);
            ProductIdList.Add(279, 775);
            ProductIdList.Add(280, 776);
            ProductIdList.Add(281, 777);
            ProductIdList.Add(282, 778);
            ProductIdList.Add(283, 779);
            ProductIdList.Add(284, 780);
            ProductIdList.Add(285, 781);
            ProductIdList.Add(286, 782);
            ProductIdList.Add(287, 783);
            ProductIdList.Add(288, 784);
            ProductIdList.Add(289, 785);
            ProductIdList.Add(290, 786);
            ProductIdList.Add(291, 787);
            ProductIdList.Add(292, 788);
            ProductIdList.Add(293, 789);
            ProductIdList.Add(294, 790);
            ProductIdList.Add(295, 791);
            ProductIdList.Add(296, 792);
            ProductIdList.Add(297, 793);
            ProductIdList.Add(298, 794);
            ProductIdList.Add(299, 795);
            ProductIdList.Add(300, 796);
            ProductIdList.Add(301, 797);
            ProductIdList.Add(302, 798);
            ProductIdList.Add(303, 799);
            ProductIdList.Add(304, 800);
            ProductIdList.Add(305, 801);
            ProductIdList.Add(306, 802);
            ProductIdList.Add(307, 803);
            ProductIdList.Add(308, 804);
            ProductIdList.Add(309, 805);
            ProductIdList.Add(310, 806);
            ProductIdList.Add(311, 807);
            ProductIdList.Add(312, 808);
            ProductIdList.Add(313, 809);
            ProductIdList.Add(314, 810);
            ProductIdList.Add(315, 811);
            ProductIdList.Add(316, 812);
            ProductIdList.Add(317, 813);
            ProductIdList.Add(318, 814);
            ProductIdList.Add(319, 815);
            ProductIdList.Add(320, 816);
            ProductIdList.Add(321, 817);
            ProductIdList.Add(322, 818);
            ProductIdList.Add(323, 819);
            ProductIdList.Add(324, 820);
            ProductIdList.Add(325, 821);
            ProductIdList.Add(326, 822);
            ProductIdList.Add(327, 823);
            ProductIdList.Add(328, 824);
            ProductIdList.Add(329, 825);
            ProductIdList.Add(330, 826);
            ProductIdList.Add(331, 827);
            ProductIdList.Add(332, 828);
            ProductIdList.Add(333, 829);
            ProductIdList.Add(334, 830);
            ProductIdList.Add(335, 831);
            ProductIdList.Add(336, 832);
            ProductIdList.Add(337, 833);
            ProductIdList.Add(338, 834);
            ProductIdList.Add(339, 835);
            ProductIdList.Add(340, 836);
            ProductIdList.Add(341, 837);
            ProductIdList.Add(342, 838);
            ProductIdList.Add(343, 839);
            ProductIdList.Add(344, 840);
            ProductIdList.Add(345, 841);
            ProductIdList.Add(346, 842);
            ProductIdList.Add(347, 843);
            ProductIdList.Add(348, 844);
            ProductIdList.Add(349, 845);
            ProductIdList.Add(350, 846);
            ProductIdList.Add(351, 847);
            ProductIdList.Add(352, 848);
            ProductIdList.Add(353, 849);
            ProductIdList.Add(354, 850);
            ProductIdList.Add(355, 851);
            ProductIdList.Add(356, 852);
            ProductIdList.Add(357, 853);
            ProductIdList.Add(358, 854);
            ProductIdList.Add(359, 855);
            ProductIdList.Add(360, 856);
            ProductIdList.Add(361, 857);
            ProductIdList.Add(362, 858);
            ProductIdList.Add(363, 859);
            ProductIdList.Add(364, 860);
            ProductIdList.Add(365, 861);
            ProductIdList.Add(366, 862);
            ProductIdList.Add(367, 863);
            ProductIdList.Add(368, 864);
            ProductIdList.Add(369, 865);
            ProductIdList.Add(370, 866);
            ProductIdList.Add(371, 867);
            ProductIdList.Add(372, 868);
            ProductIdList.Add(373, 869);
            ProductIdList.Add(374, 870);
            ProductIdList.Add(375, 871);
            ProductIdList.Add(376, 872);
            ProductIdList.Add(377, 873);
            ProductIdList.Add(378, 874);
            ProductIdList.Add(379, 875);
            ProductIdList.Add(380, 876);
            ProductIdList.Add(381, 877);
            ProductIdList.Add(382, 878);
            ProductIdList.Add(383, 879);
            ProductIdList.Add(384, 880);
            ProductIdList.Add(385, 881);
            ProductIdList.Add(386, 882);
            ProductIdList.Add(387, 883);
            ProductIdList.Add(388, 884);
            ProductIdList.Add(389, 885);
            ProductIdList.Add(390, 886);
            ProductIdList.Add(391, 887);
            ProductIdList.Add(392, 888);
            ProductIdList.Add(393, 889);
            ProductIdList.Add(394, 890);
            ProductIdList.Add(395, 891);
            ProductIdList.Add(396, 892);
            ProductIdList.Add(397, 893);
            ProductIdList.Add(398, 894);
            ProductIdList.Add(399, 895);
            ProductIdList.Add(400, 896);
            ProductIdList.Add(401, 897);
            ProductIdList.Add(402, 898);
            ProductIdList.Add(403, 899);
            ProductIdList.Add(404, 900);
            ProductIdList.Add(405, 901);
            ProductIdList.Add(406, 902);
            ProductIdList.Add(407, 903);
            ProductIdList.Add(408, 904);
            ProductIdList.Add(409, 905);
            ProductIdList.Add(410, 906);
            ProductIdList.Add(411, 907);
            ProductIdList.Add(412, 908);
            ProductIdList.Add(413, 909);
            ProductIdList.Add(414, 910);
            ProductIdList.Add(415, 911);
            ProductIdList.Add(416, 912);
            ProductIdList.Add(417, 913);
            ProductIdList.Add(418, 914);
            ProductIdList.Add(419, 915);
            ProductIdList.Add(420, 916);
            ProductIdList.Add(421, 917);
            ProductIdList.Add(422, 918);
            ProductIdList.Add(423, 919);
            ProductIdList.Add(424, 920);
            ProductIdList.Add(425, 921);
            ProductIdList.Add(426, 922);
            ProductIdList.Add(427, 923);
            ProductIdList.Add(428, 924);
            ProductIdList.Add(429, 925);
            ProductIdList.Add(430, 926);
            ProductIdList.Add(431, 927);
            ProductIdList.Add(432, 928);
            ProductIdList.Add(433, 929);
            ProductIdList.Add(434, 930);
            ProductIdList.Add(435, 931);
            ProductIdList.Add(436, 932);
            ProductIdList.Add(437, 933);
            ProductIdList.Add(438, 934);
            ProductIdList.Add(439, 935);
            ProductIdList.Add(440, 936);
            ProductIdList.Add(441, 937);
            ProductIdList.Add(442, 938);
            ProductIdList.Add(443, 939);
            ProductIdList.Add(444, 940);
            ProductIdList.Add(445, 941);
            ProductIdList.Add(446, 942);
            ProductIdList.Add(447, 943);
            ProductIdList.Add(448, 944);
            ProductIdList.Add(449, 945);
            ProductIdList.Add(450, 946);
            ProductIdList.Add(451, 947);
            ProductIdList.Add(452, 948);
            ProductIdList.Add(453, 949);
            ProductIdList.Add(454, 950);
            ProductIdList.Add(455, 951);
            ProductIdList.Add(456, 952);
            ProductIdList.Add(457, 953);
            ProductIdList.Add(458, 954);
            ProductIdList.Add(459, 955);
            ProductIdList.Add(460, 956);
            ProductIdList.Add(461, 957);
            ProductIdList.Add(462, 958);
            ProductIdList.Add(463, 959);
            ProductIdList.Add(464, 960);
            ProductIdList.Add(465, 961);
            ProductIdList.Add(466, 962);
            ProductIdList.Add(467, 963);
            ProductIdList.Add(468, 964);
            ProductIdList.Add(469, 965);
            ProductIdList.Add(470, 966);
            ProductIdList.Add(471, 967);
            ProductIdList.Add(472, 968);
            ProductIdList.Add(473, 969);
            ProductIdList.Add(474, 970);
            ProductIdList.Add(475, 971);
            ProductIdList.Add(476, 972);
            ProductIdList.Add(477, 973);
            ProductIdList.Add(478, 974);
            ProductIdList.Add(479, 975);
            ProductIdList.Add(480, 976);
            ProductIdList.Add(481, 977);
            ProductIdList.Add(482, 978);
            ProductIdList.Add(483, 979);
            ProductIdList.Add(484, 980);
            ProductIdList.Add(485, 981);
            ProductIdList.Add(486, 982);
            ProductIdList.Add(487, 983);
            ProductIdList.Add(488, 984);
            ProductIdList.Add(489, 985);
            ProductIdList.Add(490, 986);
            ProductIdList.Add(491, 987);
            ProductIdList.Add(492, 988);
            ProductIdList.Add(493, 989);
            ProductIdList.Add(494, 990);
            ProductIdList.Add(495, 991);
            ProductIdList.Add(496, 992);
            ProductIdList.Add(497, 993);
            ProductIdList.Add(498, 994);
            ProductIdList.Add(499, 995);
            ProductIdList.Add(500, 996);
            ProductIdList.Add(501, 997);
            ProductIdList.Add(502, 998);
            ProductIdList.Add(503, 999);

        }
    }

    public class Statistics
    {
        public Statistics()
        {
           Date= System.DateTime.Now;
        }
        public DateTime Date{ get; set; }
        public int ProcessorId { get; set; }
        public long Time { get; set; }
        
    }


}
