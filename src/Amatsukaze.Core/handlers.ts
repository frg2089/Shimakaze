import { type Client, type Config, type Quotable, type Sendable, createClient } from 'oicq'
import { stderr } from 'process'
import { setEvents } from './events'

let _client: Client | undefined

const log = (level: string, msg: any, ...args: any[]) => {
  stderr.write(JSON.stringify({ type: 'log', level, msg, args }))
  stderr.write('\n')
}

const event = (event: string, args: any) => {
  stderr.write(JSON.stringify({ type: 'event', event, args }))
  stderr.write('\n')
}

const logger = {
  trace: (msg: any, ...args: any[]) => { log('trace', msg, ...args) },
  debug: (msg: any, ...args: any[]) => { log('debug', msg, ...args) },
  info: (msg: any, ...args: any[]) => { log('info', msg, ...args) },
  warn: (msg: any, ...args: any[]) => { log('warn', msg, ...args) },
  error: (msg: any, ...args: any[]) => { log('error', msg, ...args) },
  fatal: (msg: any, ...args: any[]) => { log('fatal', msg, ...args) },
  mark: (msg: any, ...args: any[]) => { log('mark', msg, ...args) }
}

export const init = (config: Config & { uin: number }) => {
  if (_client) return 'duplicate'
  _client = createClient(config.uin, config)
  _client.logger = logger
  setEvents(_client, event)
  return 'ok'
}

export const sendPrivateMsg = async (args: { user_id: number, message: Sendable, source?: Quotable }) => {
  return await _client?.sendPrivateMsg(args.user_id, args.message, args.source)
}

export const sendGroupMsg = async (args: { group_id: number, message: Sendable, source?: Quotable }) => {
  return await _client?.sendGroupMsg(args.group_id, args.message, args.source)
}

export const sendDiscussMsg = async (args: { discuss_id: number, message: Sendable, source?: Quotable }) => {
  return await _client?.sendDiscussMsg(args.discuss_id, args.message, args.source)
}

export const sendTempMsg = async (args: { group_id: number, user_id: number, message: Sendable }) => {
  return await _client?.sendTempMsg(args.group_id, args.user_id, args.message)
}

export const sendGroupPoke = async (args: { group_id: number, user_id: number }) => {
  return await _client?.sendGroupPoke(args.group_id, args.user_id)
}

export const login = async (args: { password?: string }) => {
  await _client?.login(args.password)
  return 'ok'
}

export const submitSlider = (args: { ticket: string }) => {
  _client?.submitSlider(args.ticket)
  return 'ok'
}

export const submitSmsCode = async (args: { code: string }) => {
  _client?.submitSmsCode(args.code)
  return 'ok'
}

export const sendSmsCode = async () => {
  _client?.sendSmsCode()
  _client?.fetchQrcode()
  return 'ok'
}

export const fetchQrcode = async () => {
  _client?.fetchQrcode()
  return 'ok'
}
