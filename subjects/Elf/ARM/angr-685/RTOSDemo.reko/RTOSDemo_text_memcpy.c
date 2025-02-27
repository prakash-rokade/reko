// RTOSDemo_text_memcpy.c
// Generated by decompiling RTOSDemo.axf
// using Reko decompiler version 0.11.5.0.

#include "RTOSDemo.h"

// 0000A5C4: FlagGroup bool memcpy(Register (ptr32 Eq_n) r0, Register (ptr32 Eq_n) r1, Register (ptr32 Eq_n) r2, Register out ptr32 r4Out, Register out ptr32 r5Out, Register out ptr32 r6Out, Register out ptr32 r7Out)
// Called from:
//      prvCopyDataToQueue
//      prvCopyDataFromQueue
//      xQueueCRReceive
//      xQueueCRReceiveFromISR
bool memcpy(struct Eq_n * r0, struct Eq_n * r1, struct Eq_n * r2, ptr32 & r4Out, ptr32 & r5Out, ptr32 & r6Out, ptr32 & r7Out)
{
	struct Eq_n * r5_n = r0;
	if (r2 > (char *) (&g_dw000D) + 2)
	{
		if ((r1 | r0) << 30 != 0x00)
		{
			r5_n = r0;
l0000A630:
			struct Eq_n * r3_n = null;
			do
			{
				Mem102[r5_n + r3_n:byte] = Mem98[r1 + r3_n:byte];
				++r3_n;
			} while (r3_n != r2);
l0000A63C:
			r4Out = r4_n;
			r5Out = r5_n;
			r6Out = r6_n;
			r7Out = r7_n;
			return Z_n;
		}
		struct Eq_n * r4_n = r1;
		struct Eq_n * r3_n = r0;
		struct Eq_n * r5_n = r0 + ((r2 - 0x10 >> 4) + 0x01 << 4) / 16;
		do
		{
			r3_n->a0000[0] = r4_n->a0000[0];
			r3_n->dw0004 = r4_n->dw0004;
			r3_n->dw0008 = r4_n->dw0008;
			r3_n->dw000C = r4_n->dw000C;
			++r3_n;
			++r4_n;
		} while (r5_n != r3_n);
		ui32 r6_n = r2 - 0x10 & ~0x0F;
		r5_n = r0 + (r6_n + 0x10) / 16;
		r1 += (r6_n + 0x10) / 16;
		if ((r2 & 0x0F) > 0x03)
		{
			uint32 r6_n = (r2 & 0x0F) - 0x04;
			int32 r3_n = 0x00;
			uint32 r4_n = (r6_n >> 2) + 0x01;
			do
			{
				r5_n[r3_n / 16] = r1[r3_n / 16];
				r3_n += 0x04;
			} while (r3_n != r4_n << 2);
			struct Eq_n * r3_n = (r6_n & ~0x03) + 0x04;
			r2 &= 0x03;
			r1 += r3_n;
			r5_n += r3_n;
		}
		else
			r2 &= 0x0F;
	}
	if (r2 == null)
		goto l0000A63C;
	goto l0000A630;
}

