#region License
/* 
 * Copyright (C) 1999-2023 John Källén.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion
 
namespace Reko.Arch.Msp430
{
    public enum Mnemonics
    {
        invalid,

        add,
        addc,
        and,
        bic,
        bis,
        bit,
        call,
        cmp,
        dadd,
        dint,
        eint,

        jc,
        jge,
        jl,
        jmp,
        jn,
        jnc,
        jnz,
        jz,

        mov,
        push,
        rrc,
        reti,
        rra,
        sub,
        subc,
        swpb,
        sxt,
        xor,

        // 430X
        adda,
        br,
        calla,
        cmpa,
        mova,
        popm,
        pushm,
        ret,
        rlam,
        rram,
        rrax,
        rrcm,
        rrum,
        suba,
    }
}