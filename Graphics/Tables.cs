using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//                                                                      Published default Huffman tables
namespace graphics
{
    public struct huffman
    {
        public int code;
        public int count;
        public int outcome;
    }



    public class Tables
    {
            public static bool skip = false;
            private int[] bitstream = new int[64];

            private byte currentByte = 0; //current byte being bit shifted

            public static byte bitPosition = 0x80; //bit to be shifted from compressed huffman stream

            public huffman[] HDC1 = new huffman[256];
            public huffman[] HDC2 = new huffman[256];
            public huffman[] HAC1 = new huffman[256];
            public huffman[] HAC2 = new huffman[256];

            public int[,] Qtable1 = new int[8, 8];
            public int[,] Qtable2 = new int[8, 8];
            public int[,] Qtable3 = new int[8, 8];
            public int[,] Qtable4 = new int[8, 8];

             public Tables() //constructor
        {   
//***************************************************************************************************************************************************
//                                                                   Default Huffman Tables 
//                                                                          DC 0
//        
//***************************************************************************************************************************************************
            HDC1[0].code = 0;       HDC1[0].count = 2;  HDC1[0].outcome = 0;
            HDC1[1].code = 2;       HDC1[1].count = 3;  HDC1[1].outcome = 1;
            HDC1[2].code = 3;       HDC1[2].count = 3;  HDC1[2].outcome = 2;
            HDC1[3].code = 4;       HDC1[3].count = 3;  HDC1[3].outcome = 3;
            HDC1[4].code = 5;       HDC1[4].count = 3;  HDC1[4].outcome = 4;
            HDC1[5].code = 6;       HDC1[5].count = 3;  HDC1[5].outcome = 5;
            HDC1[6].code =0XE;      HDC1[6].count = 4;  HDC1[6].outcome = 6;
            HDC1[7].code = 0X1E;    HDC1[7].count = 5;  HDC1[7].outcome = 7;
            HDC1[8].code = 0X3E;    HDC1[8].count = 6;  HDC1[8].outcome = 8;
            HDC1[9].code = 0X7E;    HDC1[9].count = 7;  HDC1[9].outcome = 9;
            HDC1[10].code = 0XFE;   HDC1[10].count = 8; HDC1[10].outcome = 10;
            HDC1[11].code = 0X1FE;  HDC1[11].count = 9; HDC1[11].outcome = 11;
//***************************************************************************************************************************************************
//                                                                   Default Huffman Tables
//                                                                           AC 0
//        
//***************************************************************************************************************************************************
            HAC1[0].code = 0;       HAC1[0].count = 2;   HAC1[0].outcome = 1; //
            HAC1[1].code = 1;       HAC1[1].count = 2;   HAC1[1].outcome = 2; //
            HAC1[2].code = 4;       HAC1[2].count = 3;   HAC1[2].outcome = 3; //
            HAC1[3].code = 0XA;     HAC1[3].count = 4;   HAC1[3].outcome = 0; //
            HAC1[4].code = 0XB;     HAC1[4].count = 4;   HAC1[4].outcome = 4; //
            HAC1[5].code = 0XC;     HAC1[5].count = 4;   HAC1[5].outcome = 0X11;  //
            HAC1[6].code = 0X1A;    HAC1[6].count = 5;   HAC1[6].outcome = 5; //
            HAC1[7].code = 0X1B;    HAC1[7].count = 5;   HAC1[7].outcome = 0X21;  //
            HAC1[8].code = 0X38;    HAC1[8].count = 6;   HAC1[8].outcome = 0X6; //
            HAC1[9].code = 0X39;    HAC1[9].count = 6;   HAC1[9].outcome = 0X12; //

            HAC1[10].code = 0X3A;    HAC1[10].count = 6;   HAC1[10].outcome = 0X31; //
            HAC1[11].code = 0X3B;   HAC1[11].count = 6;  HAC1[11].outcome = 0X41; //
            HAC1[12].code = 0X78;   HAC1[12].count = 7;  HAC1[12].outcome = 0X7; //
            HAC1[13].code = 0X79;   HAC1[13].count = 7;  HAC1[13].outcome = 0X13; //

            HAC1[14].code = 0XFA;   HAC1[14].count = 8;  HAC1[14].outcome = 0X81; //
            HAC1[15].code = 0XF8;   HAC1[15].count = 8;  HAC1[15].outcome = 0X22;  //
            HAC1[16].code = 0X1F6;  HAC1[16].count = 9;  HAC1[16].outcome = 0X14;  //
            HAC1[17].code = 0X1F7;  HAC1[17].count = 9;  HAC1[17].outcome = 0X32; //
            HAC1[18].code = 0X1F8;  HAC1[18].count = 9;  HAC1[18].outcome = 0X91; //
            HAC1[19].code = 0X1F9;  HAC1[19].count = 9;  HAC1[19].outcome = 0XA1;  //
            HAC1[20].code = 0X1FA;  HAC1[20].count = 9;  HAC1[20].outcome = 0XB1;  //
            HAC1[21].code = 0X3F6;  HAC1[21].count = 9;  HAC1[21].outcome = 0X8; //
            HAC1[22].code = 0X3F7;  HAC1[22].count = 10; HAC1[22].outcome = 0X23; //
            HAC1[23].code = 0X3F8;  HAC1[23].count = 10; HAC1[23].outcome = 0X42; //
            HAC1[24].code = 0X3FA;  HAC1[24].count = 10; HAC1[24].outcome = 0XC1; //

            HAC1[25].code = 0X7F6;  HAC1[25].count = 11; HAC1[25].outcome = 0X15;  //
            HAC1[26].code = 0X7F7;  HAC1[26].count = 11; HAC1[26].outcome = 0X33;  //

            HAC1[27].code = 0X7FC0; HAC1[27].count = 15; HAC1[27].outcome = 0X82; //
            HAC1[28].code = 0XFF82; HAC1[28].count = 16; HAC1[28].outcome = 0X9; //
            HAC1[29].code = 0XFF83; HAC1[29].count = 16; HAC1[29].outcome = 0XA; //

            HAC1[30].code = 0XFF84; HAC1[30].count = 16; HAC1[30].outcome = 0X16; //
            HAC1[31].code = 0XFF85; HAC1[31].count = 16; HAC1[31].outcome = 0x17; //
            HAC1[32].code = 0XFF86; HAC1[32].count = 16; HAC1[32].outcome = 0x18; //
            HAC1[33].code = 0XFF87; HAC1[33].count = 16; HAC1[33].outcome = 0x19; //
            HAC1[34].code = 0XFF88; HAC1[34].count = 16; HAC1[34].outcome = 0x1A; //
            HAC1[35].code = 0XFF89; HAC1[35].count = 16; HAC1[35].outcome = 0x24; //
            HAC1[36].code = 0XFF8A; HAC1[36].count = 16; HAC1[36].outcome = 0x25; //
            HAC1[37].code = 0XFF8B; HAC1[37].count = 16; HAC1[37].outcome = 0x26; //
            HAC1[38].code = 0XFF8C; HAC1[38].count = 16; HAC1[38].outcome = 0x27; //
            HAC1[39].code = 0XFF8D; HAC1[39].count = 16; HAC1[39].outcome = 0x28;  //
            HAC1[40].code = 0XFF8E; HAC1[40].count = 16; HAC1[40].outcome = 0x29;  //

            HAC1[41].code = 0XFF8F; HAC1[41].count = 16; HAC1[41].outcome = 0x2A;  //
            HAC1[42].code = 0XFF90; HAC1[42].count = 16; HAC1[42].outcome = 0x34;  //
            HAC1[43].code = 0XFF91; HAC1[43].count = 16; HAC1[43].outcome = 0x35;  //
            HAC1[44].code = 0XFF92; HAC1[44].count = 16; HAC1[44].outcome = 0x36;  //
            HAC1[45].code = 0XFF93; HAC1[45].count = 16; HAC1[45].outcome = 0x37;  //
            HAC1[46].code = 0XFF94; HAC1[46].count = 16; HAC1[46].outcome = 0x38;  //
            HAC1[47].code = 0XFF95; HAC1[47].count = 16; HAC1[47].outcome = 0x39;  //
            HAC1[48].code = 0XFF96; HAC1[48].count = 16; HAC1[48].outcome = 0x3A;  //
            HAC1[49].code = 0XFF97; HAC1[49].count = 16; HAC1[49].outcome = 0x43;  //
            HAC1[50].code = 0XFF98; HAC1[50].count = 16; HAC1[50].outcome = 0x44;  //

            HAC1[51].code = 0XFF99; HAC1[51].count = 16; HAC1[51].outcome = 0x45;  //
            HAC1[52].code = 0XFF9A; HAC1[52].count = 16; HAC1[52].outcome = 0x46;  //
            HAC1[53].code = 0XFF9B; HAC1[53].count = 16; HAC1[53].outcome = 0X47;  //
            HAC1[54].code = 0XFF9C; HAC1[54].count = 16; HAC1[54].outcome = 0X48;  //
            HAC1[55].code = 0XFF9D; HAC1[55].count = 16; HAC1[55].outcome = 0X49;  //
            HAC1[56].code = 0XFF9E; HAC1[56].count = 16; HAC1[56].outcome = 0X4A;  //
            HAC1[57].code = 0XFFB7; HAC1[57].count = 16; HAC1[57].outcome = 0X83;  //
            HAC1[58].code = 0XFFB8; HAC1[58].count = 16; HAC1[58].outcome = 0X84;  //
            HAC1[59].code = 0XFFB9; HAC1[59].count = 16; HAC1[59].outcome = 0X85; //
            HAC1[60].code = 0XFFBA; HAC1[60].count = 16; HAC1[60].outcome = 0X86;  //

            HAC1[61].code = 0XFFBB; HAC1[61].count = 16; HAC1[61].outcome = 0X87; //
            HAC1[62].code = 0XFFBC; HAC1[62].count = 16; HAC1[62].outcome = 0X88; //
            HAC1[63].code = 0XFFBD; HAC1[63].count = 16; HAC1[63].outcome = 0X89; //
            HAC1[64].code = 0XFFBE; HAC1[64].count = 16; HAC1[64].outcome = 0X8A; //
            HAC1[65].code = 0XFFBF; HAC1[65].count = 16; HAC1[65].outcome = 0X92; //
            HAC1[66].code = 0XFFC0; HAC1[66].count = 16; HAC1[66].outcome = 0X93; //
            HAC1[67].code = 0XFFC1; HAC1[67].count = 16; HAC1[67].outcome = 0X94; //
            HAC1[68].code = 0XFFC2; HAC1[68].count = 16; HAC1[68].outcome = 0X95; //
            HAC1[69].code = 0XFFC3; HAC1[69].count = 16; HAC1[69].outcome = 0X96; //
            HAC1[70].code = 0XFFC4; HAC1[70].count = 16; HAC1[70].outcome = 0X97; //

            HAC1[71].code = 0XFFC5; HAC1[71].count = 16; HAC1[71].outcome = 0X98; //
            HAC1[72].code = 0XFFC6; HAC1[72].count = 16; HAC1[72].outcome = 0X99; //
            HAC1[73].code = 0XFFC7; HAC1[73].count = 16; HAC1[73].outcome = 0X9A; //
            HAC1[74].code = 0XFFC8; HAC1[74].count = 16; HAC1[74].outcome = 0XA2; //
            HAC1[75].code = 0XFFC9; HAC1[75].count = 16; HAC1[75].outcome = 0XA3; //
            HAC1[76].code = 0XFFCA; HAC1[76].count = 16; HAC1[76].outcome = 0XA4; //
            HAC1[77].code = 0XFFCB; HAC1[77].count = 16; HAC1[77].outcome = 0XA5; //
            HAC1[78].code = 0XFFCC; HAC1[78].count = 16; HAC1[78].outcome = 0XA6; //
            HAC1[79].code = 0XFFCD; HAC1[79].count = 16; HAC1[79].outcome = 0XA7; //
            HAC1[80].code = 0XFFCE; HAC1[80].count = 16; HAC1[80].outcome = 0XA8; //

            HAC1[81].code = 0XFFCF; HAC1[81].count = 16; HAC1[81].outcome = 0XA9; //
            HAC1[82].code = 0XFFD0; HAC1[82].count = 16; HAC1[82].outcome = 0XAA; //
            HAC1[83].code = 0XFFD1; HAC1[83].count = 16; HAC1[83].outcome = 0XB2; //
            HAC1[84].code = 0XFFD2; HAC1[84].count = 16; HAC1[84].outcome = 0XB3; //
            HAC1[85].code = 0XFFD3; HAC1[85].count = 16; HAC1[85].outcome = 0XB4; //
            HAC1[86].code = 0XFFD4; HAC1[86].count = 16; HAC1[86].outcome = 0XB5; //
            HAC1[87].code = 0XFFD5; HAC1[87].count = 16; HAC1[87].outcome = 0XB6; //
            HAC1[88].code = 0XFFD6; HAC1[88].count = 16; HAC1[88].outcome = 0XB7; //
            HAC1[89].code = 0XFFD7; HAC1[89].count = 16; HAC1[89].outcome = 0XB8; //
            HAC1[90].code = 0XFFD8; HAC1[90].count = 16; HAC1[90].outcome = 0XB9; //
            HAC1[91].code = 0XFFD9; HAC1[91].count = 16; HAC1[91].outcome = 0XBA; //
            HAC1[92].code = 0XFFDA; HAC1[92].count = 16; HAC1[92].outcome = 0XC2; //
            HAC1[93].code = 0XFFDB; HAC1[93].count = 16; HAC1[93].outcome = 0XC3; //
            HAC1[94].code = 0XFFDC; HAC1[94].count = 16; HAC1[94].outcome = 0XC4; //
            HAC1[95].code = 0XFFDD; HAC1[95].count = 16; HAC1[95].outcome = 0XC5; //
            HAC1[96].code = 0XFFDE; HAC1[96].count = 16; HAC1[96].outcome = 0XC6; //
            HAC1[97].code = 0XFFDF; HAC1[97].count = 16; HAC1[97].outcome = 0XC7; //
            HAC1[98].code = 0XFFE0; HAC1[98].count = 16; HAC1[98].outcome = 0XC8; //
            HAC1[99].code = 0XFFE1; HAC1[99].count = 16; HAC1[99].outcome = 0XC9; //
            HAC1[100].code = 0XFFE2; HAC1[100].count = 16; HAC1[100].outcome = 0XCA; //


//***************************************************************************************************************************************************
//                                                                   Default Huffman Tables
//                                                                          DC 1
//        
//***************************************************************************************************************************************************
            HDC2[0].code = 0; HDC2[0].count = 2; HDC2[0].outcome = 0;
            HDC2[1].code = 2; HDC2[1].count = 3; HDC2[1].outcome = 1;
            HDC2[2].code = 3; HDC2[2].count = 3; HDC2[2].outcome = 2;
            HDC2[3].code = 4; HDC2[3].count = 3; HDC2[3].outcome = 3;
            HDC2[4].code = 5; HDC2[4].count = 3; HDC2[4].outcome = 4;
            HDC2[5].code = 6; HDC2[5].count = 3; HDC2[5].outcome = 5;
            HDC2[6].code = 0XE; HDC2[6].count = 4; HDC2[6].outcome = 6;
            HDC2[7].code = 0X1E; HDC2[7].count = 5; HDC2[7].outcome = 7;
            HDC2[8].code = 0X3E; HDC2[8].count = 6; HDC2[8].outcome = 8;
            HDC2[9].code = 0X7E; HDC2[9].count = 7; HDC2[9].outcome = 9;
            HDC2[10].code = 0XFE; HDC2[10].count = 8; HDC2[10].outcome = 10;
            HDC2[11].code = 0X1FE; HDC2[11].count = 9; HDC2[11].outcome = 11;
            //***************************************************************************************************************************************************
            //                                                                   Default Huffman Tables
            //                                                                           AC 1
            //        
            //***************************************************************************************************************************************************
            HAC2[0].code = 0; HAC2[0].count = 2; HAC2[0].outcome = 1; //
            HAC2[1].code = 1; HAC2[1].count = 2; HAC2[1].outcome = 2; //
            HAC2[2].code = 4; HAC2[2].count = 3; HAC2[2].outcome = 3; //
            HAC2[3].code = 0XA; HAC2[3].count = 4; HAC2[3].outcome = 0; //
            HAC2[4].code = 0XB; HAC2[4].count = 4; HAC2[4].outcome = 4; //
            HAC2[5].code = 0XC; HAC2[5].count = 4; HAC2[5].outcome = 0X11;  //
            HAC2[6].code = 0X1A; HAC2[6].count = 5; HAC2[6].outcome = 5; //
            HAC2[7].code = 0X1B; HAC2[7].count = 5; HAC2[7].outcome = 0X21;  //
            HAC2[8].code = 0X38; HAC2[8].count = 6; HAC2[8].outcome = 0X6; //
            HAC2[9].code = 0X39; HAC2[9].count = 6; HAC2[9].outcome = 0X12; //

            HAC2[10].code = 0X3A; HAC2[10].count = 6; HAC2[10].outcome = 0X31; //
            HAC2[11].code = 0X3B; HAC2[11].count = 6; HAC2[11].outcome = 0X41; //
            HAC2[12].code = 0X78; HAC2[12].count = 7; HAC2[12].outcome = 0X7; //
            HAC2[13].code = 0X79; HAC2[13].count = 7; HAC2[13].outcome = 0X13; //

            HAC2[14].code = 0XFA; HAC2[14].count = 8; HAC2[14].outcome = 0X81; //
            HAC2[15].code = 0XF8; HAC2[15].count = 8; HAC2[15].outcome = 0X22;  //
            HAC2[16].code = 0X1F6; HAC2[16].count = 9; HAC2[16].outcome = 0X14;  //
            HAC2[17].code = 0X1F7; HAC2[17].count = 9; HAC2[17].outcome = 0X32; //
            HAC2[18].code = 0X1F8; HAC2[18].count = 9; HAC2[18].outcome = 0X91; //
            HAC2[19].code = 0X1F9; HAC2[19].count = 9; HAC2[19].outcome = 0XA1;  //
            HAC2[20].code = 0X1FA; HAC2[20].count = 9; HAC2[20].outcome = 0XB1;  //
            HAC2[21].code = 0X3F6; HAC2[21].count = 9; HAC2[21].outcome = 0X8; //
            HAC2[22].code = 0X3F7; HAC2[22].count = 10; HAC2[22].outcome = 0X23; //
            HAC2[23].code = 0X3F8; HAC2[23].count = 10; HAC2[23].outcome = 0X42; //
            HAC2[24].code = 0X3FA; HAC2[24].count = 10; HAC2[24].outcome = 0XC1; //

            HAC2[25].code = 0X7F6; HAC2[25].count = 11; HAC2[25].outcome = 0X15;  //
            HAC2[26].code = 0X7F7; HAC2[26].count = 11; HAC2[26].outcome = 0X33;  //

            HAC2[27].code = 0X7FC0; HAC2[27].count = 15; HAC2[27].outcome = 0X82; //
            HAC2[28].code = 0XFF82; HAC2[28].count = 16; HAC2[28].outcome = 0X9; //
            HAC2[29].code = 0XFF83; HAC2[29].count = 16; HAC2[29].outcome = 0XA; //

            HAC2[30].code = 0XFF84; HAC2[30].count = 16; HAC2[30].outcome = 0X16; //
            HAC2[31].code = 0XFF85; HAC2[31].count = 16; HAC2[31].outcome = 0x17; //
            HAC2[32].code = 0XFF86; HAC2[32].count = 16; HAC2[32].outcome = 0x18; //
            HAC2[33].code = 0XFF87; HAC2[33].count = 16; HAC2[33].outcome = 0x19; //
            HAC2[34].code = 0XFF88; HAC2[34].count = 16; HAC2[34].outcome = 0x1A; //
            HAC2[35].code = 0XFF89; HAC2[35].count = 16; HAC2[35].outcome = 0x24; //
            HAC2[36].code = 0XFF8A; HAC2[36].count = 16; HAC2[36].outcome = 0x25; //
            HAC2[37].code = 0XFF8B; HAC2[37].count = 16; HAC2[37].outcome = 0x26; //
            HAC2[38].code = 0XFF8C; HAC2[38].count = 16; HAC2[38].outcome = 0x27; //
            HAC2[39].code = 0XFF8D; HAC2[39].count = 16; HAC2[39].outcome = 0x28;  //
            HAC2[40].code = 0XFF8E; HAC2[40].count = 16; HAC2[40].outcome = 0x29;  //

            HAC2[41].code = 0XFF8F; HAC2[41].count = 16; HAC2[41].outcome = 0x2A;  //
            HAC2[42].code = 0XFF90; HAC2[42].count = 16; HAC2[42].outcome = 0x34;  //
            HAC2[43].code = 0XFF91; HAC2[43].count = 16; HAC2[43].outcome = 0x35;  //
            HAC2[44].code = 0XFF92; HAC2[44].count = 16; HAC2[44].outcome = 0x36;  //
            HAC2[45].code = 0XFF93; HAC2[45].count = 16; HAC2[45].outcome = 0x37;  //
            HAC2[46].code = 0XFF94; HAC2[46].count = 16; HAC2[46].outcome = 0x38;  //
            HAC2[47].code = 0XFF95; HAC2[47].count = 16; HAC2[47].outcome = 0x39;  //
            HAC2[48].code = 0XFF96; HAC2[48].count = 16; HAC2[48].outcome = 0x3A;  //
            HAC2[49].code = 0XFF97; HAC2[49].count = 16; HAC2[49].outcome = 0x43;  //
            HAC2[50].code = 0XFF98; HAC2[50].count = 16; HAC2[50].outcome = 0x44;  //

            HAC2[51].code = 0XFF99; HAC2[51].count = 16; HAC2[51].outcome = 0x45;  //
            HAC2[52].code = 0XFF9A; HAC2[52].count = 16; HAC2[52].outcome = 0x46;  //
            HAC2[53].code = 0XFF9B; HAC2[53].count = 16; HAC2[53].outcome = 0X47;  //
            HAC2[54].code = 0XFF9C; HAC2[54].count = 16; HAC2[54].outcome = 0X48;  //
            HAC2[55].code = 0XFF9D; HAC2[55].count = 16; HAC2[55].outcome = 0X49;  //
            HAC2[56].code = 0XFF9E; HAC2[56].count = 16; HAC2[56].outcome = 0X4A;  //
            HAC2[57].code = 0XFFB7; HAC2[57].count = 16; HAC2[57].outcome = 0X83;  //
            HAC2[58].code = 0XFFB8; HAC2[58].count = 16; HAC2[58].outcome = 0X84;  //
            HAC2[59].code = 0XFFB9; HAC2[59].count = 16; HAC2[59].outcome = 0X85; //
            HAC2[60].code = 0XFFBA; HAC2[60].count = 16; HAC2[60].outcome = 0X86;  //

            HAC2[61].code = 0XFFBB; HAC2[61].count = 16; HAC2[61].outcome = 0X87; //
            HAC2[62].code = 0XFFBC; HAC2[62].count = 16; HAC2[62].outcome = 0X88; //
            HAC2[63].code = 0XFFBD; HAC2[63].count = 16; HAC2[63].outcome = 0X89; //
            HAC2[64].code = 0XFFBE; HAC2[64].count = 16; HAC2[64].outcome = 0X8A; //
            HAC2[65].code = 0XFFBF; HAC2[65].count = 16; HAC2[65].outcome = 0X92; //
            HAC2[66].code = 0XFFC0; HAC2[66].count = 16; HAC2[66].outcome = 0X93; //
            HAC2[67].code = 0XFFC1; HAC2[67].count = 16; HAC2[67].outcome = 0X94; //
            HAC2[68].code = 0XFFC2; HAC2[68].count = 16; HAC2[68].outcome = 0X95; //
            HAC2[69].code = 0XFFC3; HAC2[69].count = 16; HAC2[69].outcome = 0X96; //
            HAC2[70].code = 0XFFC4; HAC2[70].count = 16; HAC2[70].outcome = 0X97; //

            HAC2[71].code = 0XFFC5; HAC2[71].count = 16; HAC2[71].outcome = 0X98; //
            HAC2[72].code = 0XFFC6; HAC2[72].count = 16; HAC2[72].outcome = 0X99; //
            HAC2[73].code = 0XFFC7; HAC2[73].count = 16; HAC2[73].outcome = 0X9A; //
            HAC2[74].code = 0XFFC8; HAC2[74].count = 16; HAC2[74].outcome = 0XA2; //
            HAC2[75].code = 0XFFC9; HAC2[75].count = 16; HAC2[75].outcome = 0XA3; //
            HAC2[76].code = 0XFFCA; HAC2[76].count = 16; HAC2[76].outcome = 0XA4; //
            HAC2[77].code = 0XFFCB; HAC2[77].count = 16; HAC2[77].outcome = 0XA5; //
            HAC2[78].code = 0XFFCC; HAC2[78].count = 16; HAC2[78].outcome = 0XA6; //
            HAC2[79].code = 0XFFCD; HAC2[79].count = 16; HAC2[79].outcome = 0XA7; //
            HAC2[80].code = 0XFFCE; HAC2[80].count = 16; HAC2[80].outcome = 0XA8; //

            HAC2[81].code = 0XFFCF; HAC2[81].count = 16; HAC2[81].outcome = 0XA9; //
            HAC2[82].code = 0XFFD0; HAC2[82].count = 16; HAC2[82].outcome = 0XAA; //
            HAC2[83].code = 0XFFD1; HAC2[83].count = 16; HAC2[83].outcome = 0XB2; //
            HAC2[84].code = 0XFFD2; HAC2[84].count = 16; HAC2[84].outcome = 0XB3; //
            HAC2[85].code = 0XFFD3; HAC2[85].count = 16; HAC2[85].outcome = 0XB4; //
            HAC2[86].code = 0XFFD4; HAC2[86].count = 16; HAC2[86].outcome = 0XB5; //
            HAC2[87].code = 0XFFD5; HAC2[87].count = 16; HAC2[87].outcome = 0XB6; //
            HAC2[88].code = 0XFFD6; HAC2[88].count = 16; HAC2[88].outcome = 0XB7; //
            HAC2[89].code = 0XFFD7; HAC2[89].count = 16; HAC2[89].outcome = 0XB8; //
            HAC2[90].code = 0XFFD8; HAC2[90].count = 16; HAC2[90].outcome = 0XB9; //
            HAC2[91].code = 0XFFD9; HAC2[91].count = 16; HAC2[91].outcome = 0XBA; //
            HAC2[92].code = 0XFFDA; HAC2[92].count = 16; HAC2[92].outcome = 0XC2; //
            HAC2[93].code = 0XFFDB; HAC2[93].count = 16; HAC2[93].outcome = 0XC3; //
            HAC2[94].code = 0XFFDC; HAC2[94].count = 16; HAC2[94].outcome = 0XC4; //
            HAC2[95].code = 0XFFDD; HAC2[95].count = 16; HAC2[95].outcome = 0XC5; //
            HAC2[96].code = 0XFFDE; HAC2[96].count = 16; HAC2[96].outcome = 0XC6; //
            HAC2[97].code = 0XFFDF; HAC2[97].count = 16; HAC2[97].outcome = 0XC7; //
            HAC2[98].code = 0XFFE0; HAC2[98].count = 16; HAC2[98].outcome = 0XC8; //
            HAC2[99].code = 0XFFE1; HAC2[99].count = 16; HAC2[99].outcome = 0XC9; //
            HAC2[100].code = 0XFFE2; HAC2[100].count = 16; HAC2[100].outcome = 0XCA; //
        }
//***************************************************************************************************************************************************
//
//
//
//*************************************************************************************************************************************************** 
        public void lumanceBlock(ref int[,] lumance, int x, int y)
        {
            int[,] temporary = new int[8, 8];
            
            JPG.yTemp += getValue(LoadCode(HDC1));
            bitstream[0] = JPG.yTemp;
            blockLoad(HAC1, bitstream);
            temporary = loadTable(ref bitstream);
            temporary = quantify(temporary, Qtable1);
            temporary = matrixTransform(temporary);
            moveCluster(temporary, ref lumance, x, y);
        }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
        public void CbBlock(ref int[,] chromance, int x, int y)
        {
            int[,] temporary = new int[8, 8];

            JPG.CbTemp += getValue(LoadCode(HDC2));
            bitstream[0] = JPG.CbTemp;
            blockLoad(HAC2, bitstream);
            temporary = loadTable(ref bitstream);
            temporary = quantify(temporary, Qtable2);
            temporary = matrixTransform(temporary);
            moveCluster(temporary, ref chromance, x, y);
        }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
        public void CrBlock(ref int[,] chromance, int x, int y)
        {
            int[,] temporary = new int[8, 8];

            JPG.CrTemp += getValue(LoadCode(HDC2));
            bitstream[0] =JPG.CrTemp;
            blockLoad(HAC2, bitstream);
            temporary = loadTable(ref bitstream);
            temporary = quantify(temporary, Qtable2);
            temporary = matrixTransform(temporary);
            moveCluster(temporary, ref chromance, x, y);
        }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            public huffman[] HuffmanTable(int decode)
            {
                huffman[] table = new huffman[256];
                int index = 0;
                int code = 0;
                int count = 0;

                for (int y = 1; y <= 16; y++)
                {
                    count += (int)(data[offset]);
                    for (int x = 1; x <= data[offset]; x++)
                    {
                        table[index].outcome = (int)(data[decode + index]);
                        table[index].count = y;
                        table[index].code = code;
                        code++;
                        index++;
                    }
                    ++offset;
                    code *= 2;
                }
                offset += count;
                return table;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            public int[,] loadTable(byte[] data)
            {
                int[,] matrix = new int[8, 8];
                matrix[0, 0] = data[offset + 0]; matrix[4, 1] = data[JPG.offset + 16]; matrix[3, 4] = data[JPG.offset + 32]; matrix[2, 7] = data[JPG.offset + 48];
                matrix[1, 0] = data[JPG.offset + 1]; matrix[3, 2] = data[JPG.offset + 17]; matrix[2, 5] = data[JPG.offset + 33]; matrix[3, 7] = data[JPG.offset + 49];
                matrix[0, 1] = data[JPG.offset + 2]; matrix[2, 3] = data[JPG.offset + 18]; matrix[1, 6] = data[JPG.offset + 34]; matrix[4, 6] = data[JPG.offset + 50];
                matrix[0, 2] = data[JPG.offset + 3]; matrix[1, 4] = data[JPG.offset + 19]; matrix[0, 7] = data[JPG.offset + 35]; matrix[5, 5] = data[JPG.offset + 51];
                matrix[1, 1] = data[JPG.offset + 4]; matrix[0, 5] = data[JPG.offset + 20]; matrix[1, 7] = data[JPG.offset + 36]; matrix[6, 4] = data[JPG.offset + 52];
                matrix[2, 0] = data[JPG.offset + 5]; matrix[0, 6] = data[JPG.offset + 21]; matrix[2, 6] = data[JPG.offset + 37]; matrix[7, 3] = data[JPG.offset + 53];
                matrix[3, 0] = data[JPG.offset + 6]; matrix[1, 5] = data[JPG.offset + 22]; matrix[3, 5] = data[JPG.offset + 38]; matrix[7, 4] = data[JPG.offset + 54];
                matrix[2, 1] = data[JPG.offset + 7]; matrix[2, 4] = data[JPG.offset + 23]; matrix[4, 4] = data[JPG.offset + 39]; matrix[6, 5] = data[JPG.offset + 55];
                matrix[1, 2] = data[JPG.offset + 8]; matrix[3, 3] = data[JPG.offset + 24]; matrix[5, 3] = data[JPG.offset + 40]; matrix[5, 6] = data[JPG.offset + 56];
                matrix[0, 3] = data[JPG.offset + 9]; matrix[4, 2] = data[JPG.offset + 25]; matrix[6, 2] = data[JPG.offset + 41]; matrix[4, 7] = data[JPG.offset + 57];
                matrix[0, 4] = data[JPG.offset + 10]; matrix[5, 1] = data[JPG.offset + 26]; matrix[7, 1] = data[JPG.offset + 42]; matrix[5, 7] = data[JPG.offset + 58];
                matrix[1, 3] = data[JPG.offset + 11]; matrix[6, 0] = data[JPG.offset + 27]; matrix[7, 2] = data[JPG.offset + 43]; matrix[6, 6] = data[JPG.offset + 59];
                matrix[2, 2] = data[JPG.offset + 12]; matrix[7, 0] = data[JPG.offset + 28]; matrix[6, 3] = data[JPG.offset + 44]; matrix[7, 5] = data[JPG.offset + 60];
                matrix[3, 1] = data[JPG.offset + 13]; matrix[6, 1] = data[JPG.offset + 29]; matrix[5, 4] = data[JPG.offset + 45]; matrix[7, 6] = data[JPG.offset + 61];
                matrix[4, 0] = data[JPG.offset + 14]; matrix[5, 2] = data[JPG.offset + 30]; matrix[4, 5] = data[JPG.offset + 46]; matrix[6, 7] = data[JPG.offset + 62];
                matrix[5, 0] = data[JPG.offset + 15]; matrix[4, 3] = data[JPG.offset + 31]; matrix[3, 6] = data[JPG.offset + 47]; matrix[7, 7] = data[JPG.offset + 63];
                JPG.offset += 64;
                return matrix;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            public int[,] loadTable(ref int[] data)
            {
                int[,] matrix = new int[8, 8];
                matrix[0, 0] = data[0]; matrix[4, 1] = data[16]; matrix[3, 4] = data[32]; matrix[2, 7] = data[48];
                matrix[1, 0] = data[1]; matrix[3, 2] = data[17]; matrix[2, 5] = data[33]; matrix[3, 7] = data[49];
                matrix[0, 1] = data[2]; matrix[2, 3] = data[18]; matrix[1, 6] = data[34]; matrix[4, 6] = data[50];
                matrix[0, 2] = data[3]; matrix[1, 4] = data[19]; matrix[0, 7] = data[35]; matrix[5, 5] = data[51];
                matrix[1, 1] = data[4]; matrix[0, 5] = data[20]; matrix[1, 7] = data[36]; matrix[6, 4] = data[52];
                matrix[2, 0] = data[5]; matrix[0, 6] = data[21]; matrix[2, 6] = data[37]; matrix[7, 3] = data[53];
                matrix[3, 0] = data[6]; matrix[1, 5] = data[22]; matrix[3, 5] = data[38]; matrix[7, 4] = data[54];
                matrix[2, 1] = data[7]; matrix[2, 4] = data[23]; matrix[4, 4] = data[39]; matrix[6, 5] = data[55];
                matrix[1, 2] = data[8]; matrix[3, 3] = data[24]; matrix[5, 3] = data[40]; matrix[5, 6] = data[56];
                matrix[0, 3] = data[9]; matrix[4, 2] = data[25]; matrix[6, 2] = data[41]; matrix[4, 7] = data[57];
                matrix[0, 4] = data[10]; matrix[5, 1] = data[26]; matrix[7, 1] = data[42]; matrix[5, 7] = data[58];
                matrix[1, 3] = data[11]; matrix[6, 0] = data[27]; matrix[7, 2] = data[43]; matrix[6, 6] = data[59];
                matrix[2, 2] = data[12]; matrix[7, 0] = data[28]; matrix[6, 3] = data[44]; matrix[7, 5] = data[60];
                matrix[3, 1] = data[13]; matrix[6, 1] = data[29]; matrix[5, 4] = data[45]; matrix[7, 6] = data[61];
                matrix[4, 0] = data[14]; matrix[5, 2] = data[30]; matrix[4, 5] = data[46]; matrix[6, 7] = data[62];
                matrix[5, 0] = data[15]; matrix[4, 3] = data[31]; matrix[3, 6] = data[47]; matrix[7, 7] = data[63];
                return matrix;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            public void moveCluster(int[,] from, ref int[,] to, int x, int y)
            {
                to[x, y] = from[0, 0]; to[x + 2, y] = from[2, 0]; to[x + 4, y] = from[4, 0]; to[x + 6, y] = from[6, 0];
                to[x, y + 1] = from[0, 1]; to[x + 2, y + 1] = from[2, 1]; to[x + 4, y + 1] = from[4, 1]; to[x + 6, y + 1] = from[6, 1];
                to[x, y + 2] = from[0, 2]; to[x + 2, y + 2] = from[2, 2]; to[x + 4, y + 2] = from[4, 2]; to[x + 6, y + 2] = from[6, 2];
                to[x, y + 3] = from[0, 3]; to[x + 2, y + 3] = from[2, 3]; to[x + 4, y + 3] = from[4, 3]; to[x + 6, y + 3] = from[6, 3];
                to[x, y + 4] = from[0, 4]; to[x + 2, y + 4] = from[2, 4]; to[x + 4, y + 4] = from[4, 4]; to[x + 6, y + 4] = from[6, 4];
                to[x, y + 5] = from[0, 5]; to[x + 2, y + 5] = from[2, 5]; to[x + 4, y + 5] = from[4, 5]; to[x + 6, y + 5] = from[6, 5];
                to[x, y + 6] = from[0, 6]; to[x + 2, y + 6] = from[2, 6]; to[x + 4, y + 6] = from[4, 6]; to[x + 6, y + 6] = from[6, 6];
                to[x, y + 7] = from[0, 7]; to[x + 2, y + 7] = from[2, 7]; to[x + 4, y + 7] = from[4, 7]; to[x + 6, y + 7] = from[6, 7];
                to[x + 1, y] = from[1, 0]; to[x + 3, y] = from[3, 0]; to[x + 5, y] = from[5, 0]; to[x + 7, y] = from[7, 0];
                to[x + 1, y + 1] = from[1, 1]; to[x + 3, y + 1] = from[3, 1]; to[x + 5, y + 1] = from[5, 1]; to[x + 7, y + 1] = from[7, 1];
                to[x + 1, y + 2] = from[1, 2]; to[x + 3, y + 2] = from[3, 2]; to[x + 5, y + 2] = from[5, 2]; to[x + 7, y + 2] = from[7, 2];
                to[x + 1, y + 3] = from[1, 3]; to[x + 3, y + 3] = from[3, 3]; to[x + 5, y + 3] = from[5, 3]; to[x + 7, y + 3] = from[7, 3];
                to[x + 1, y + 4] = from[1, 4]; to[x + 3, y + 4] = from[3, 4]; to[x + 5, y + 4] = from[5, 4]; to[x + 7, y + 4] = from[7, 4];
                to[x + 1, y + 5] = from[1, 5]; to[x + 3, y + 5] = from[3, 5]; to[x + 5, y + 5] = from[5, 5]; to[x + 7, y + 5] = from[7, 5];
                to[x + 1, y + 6] = from[1, 6]; to[x + 3, y + 6] = from[3, 6]; to[x + 5, y + 6] = from[5, 6]; to[x + 7, y + 6] = from[7, 6];
                to[x + 1, y + 7] = from[1, 7]; to[x + 3, y + 7] = from[3, 7]; to[x + 5, y + 7] = from[5, 7]; to[x + 7, y + 7] = from[7, 7];
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private int[,] matrixTransform(int[,] table)
            {
                int[,] temp = new int[8, 8];
                for (int y = 0; y < 8; y++)
                    for (int x = 0; x < 8; x++)
                        temp[x, y] = DCT(ref table, x, y);
                return temp;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private int DCT(ref int[,] table, int x, int y)
            {
                int pixel = 0;
                double xsum = 0;
                double ysum = 0;

                for (int v = 0; v < 8; v++)
                {
                    xsum = 0;
                    for (int u = 0; u < 8; u++)
                    {
                        xsum += alpha(u) * alpha(v) * table[u, v] * 
                        Math.Cos(u * Math.PI * (2 * x + 1.0) / 16.0) * 
                        Math.Cos(v * Math.PI * (2 * y + 1.0) / 16.0);
                    }
                    ysum += xsum;
                }
                return pixel = (int)(0.25 * ysum);
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private double alpha(int u)
            {
                double value = 0;
                if (u == 0) value = Math.Pow(2, -.5);
                else value = 1;
                return value;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private int[,] quantify(int[,] data, int[,] Qtable)
            {
                int[,] temporary = new int[8, 8];
                for (int y = 0; y < 8; y++)
                    for (int x = 0; x < 8; x++)
                        temporary[x, y] = data[x, y] * Qtable[x, y];
                return temporary;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private int getValue(int Nbits)
            {
                int code = 0; // huffman code

                if (Nbits == 0) return 0;
                int DeadZone = (int)(Math.Pow(2.0, (double)(Nbits - 1)) - 1); //zone that's the switch point for negative/positive values.
                int negativeStart = (-1) * (int)(Math.Pow(2.0, (double)Nbits) - 1); //most negative possibility.

                currentByte = JPG.data[JPG.offset];

                if (currentByte == 0xFF && skip == false) skip = true;
                if (currentByte != 0xFF && skip == true)
                {
                    skip = false;
                    ++JPG.offset;
                    currentByte = JPG.data[JPG.offset];
                    bitPosition = 0x80;
                }

                while (true)
                {
                    code *= 2;
                    code += (byte)((currentByte & bitPosition) / bitPosition);
                    bitPosition /= 2;
                    if (bitPosition < 0x01)
                    {
                        JPG.offset++;
                        bitPosition = 0x80;
                        currentByte = JPG.data[JPG.offset];
                        if (currentByte == 0xFF && skip == false) skip = true;
                        if (currentByte != 0xFF && skip == true)
                        {
                            ++JPG.offset;
                            currentByte = JPG.data[JPG.offset];
                            skip = false;
                        }
                    }
                    if (--Nbits <= 0) break;
                }
                if (code <= DeadZone) return (int)(negativeStart + code);
                else return (int)code;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private void blockLoad(huffman[] codes, int[] bitstream)
            {
                int outcome;

                for (int x = 1; x <= 63; )
                {
                    outcome = LoadCode(codes); //
                     if (outcome == 0)
                    {
                        for (; x <= 63;) { bitstream[x++] = 0; } //If end of block fill with zero
                        break;
                    }
                    for (int y = 0; y < ((outcome & 0xF0) / 0x10); y++) { bitstream[x++] = 0; }
                    bitstream[x++] = getValue((int)(outcome & 0xF)); // sends number of bits for pixel value obtained from compressed stream
                }
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            private int LoadCode(huffman[] table) // data stream, offset within stream, huffman table, huffman decode array
            {
                int count = 0; //current count
                int code = 0; // possible huffman code
                int k = 0;

                currentByte = JPG.data[JPG.offset];

                if (currentByte == 0xFF && skip == false) skip = true;
                if (currentByte != 0xFF && skip == true)
                {
                    skip = false;
                    ++JPG.offset;
                    currentByte = JPG.data[JPG.offset];
                    bitPosition = 0x80;
                }

                while (true)
                {
                    code *= 2;
                    code += (int)((currentByte & bitPosition) / bitPosition);
                    bitPosition /= 2;
                    if (bitPosition < 0x1)
                    {
                        JPG.offset++;
                        bitPosition = 0x80;
                        currentByte = JPG.data[JPG.offset];
                        if (currentByte == 0xFF && skip == false) skip = true;
                        if (currentByte != 0xFF && skip == true)
                        {
                            skip = false;
                            ++JPG.offset;
                            currentByte = JPG.data[JPG.offset];
                            bitPosition = 0x80;
                        }
                    }
                    ++count;
                    while (table[k].code < code) k++;
                    if (code == table[k].code && count == table[k].count) break;
                }
                return table[k].outcome;
            }
//***************************************************************************************************************************************************
//
//
//
//***************************************************************************************************************************************************
            public int[,] expandXY(int[,] frame)
            {
                int[,] temporary = new int[JPG.width, JPG.height];

                for (int y = 0; y < JPG.height; y += 2)
                    for (int x = 0; x < JPG.width; x += 2)
                    {
                        temporary[x, y] = frame[x / 2, y / 2];
                        temporary[x + 1, y] = frame[x / 2, y / 2];
                        temporary[x, y + 1] = frame[x / 2, y / 2];
                        temporary[x + 1, y + 1] = frame[x / 2, y / 2];
                    }
                return temporary;
            }
//***************************************************************************************************************************************************
//                                                                End of the World
//
//***************************************************************************************************************************************************
    }
}
