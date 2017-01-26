using System;

namespace graphics
{
    public partial class JPG
    {
        private byte currentByte = 0; //current byte being bit shifted
        enum Huffman : int { codes, length };
        private int endOfFile = 5;       //offset for end of file.  Must update before offset at 5.
        private int QtableQuantity = 0;  //quantity of quantization tables
        private int HuffmanTableDC = 0;  //quantity of huffman dc tables
        private int HuffmanTableAC = 0;  //quantity of Huffman ac tables
    }

}
